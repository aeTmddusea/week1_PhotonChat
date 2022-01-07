using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Chat;
using ExitGames.Client.Photon;

public class ChatScript : MonoBehaviour, IChatClientListener
{
    private ChatClient chatClient;
    private string currentChannelName;
    private string userName = "User";

    public InputField inputField;
    public Text outputText;

    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;
        currentChannelName = "Channel 001";
        
        chatClient = new ChatClient(this);
        chatClient.Connect(ChatSettings.Instance.AppId, "1.0", new AuthenticationValues(userName));
        AddLine(string.Format("연결중입니다.", userName));
    }

    public void AddLine(string lineString)
    {
        outputText.text += lineString + "\r\n";
    }

    public void OnApplicationQuit()
    {
        if (chatClient != null)
        {
            chatClient.Disconnect();
        }
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        if (level == DebugLevel.ERROR) Debug.LogError(message);
        else if (level == DebugLevel.WARNING) Debug.LogWarning(message);
        else Debug.Log(message);
        //throw new System.NotImplementedException();
    }

    public void OnDisconnected()
    {
        AddLine("서버와 연결이 끊어졌습니다.");
        //throw new System.NotImplementedException();
    }

    public void OnConnected()
    {
        AddLine("서버와 연결되었습니다.");
        chatClient.Subscribe(new string[] { currentChannelName }, 10);
        //throw new System.NotImplementedException();
    }

    public void OnChatStateChange(ChatState state)
    {
        Debug.Log("OnChatStateChange = " + state);
        //throw new System.NotImplementedException();
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < messages.Length; i++)
        {
            AddLine(string.Format("{0} : {1}", senders[i], messages[i].ToString()));
        }
        //throw new System.NotImplementedException();
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        Debug.Log("OnPrivateMessage : " + message);
        //throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        AddLine(string.Format("채널 입장 ({0})", string.Join(",", channels)));
        //throw new System.NotImplementedException();
    }

    public void OnUnsubscribed(string[] channels)
    {
        AddLine(string.Format("채널 퇴장 ({0})", string.Join(",", channels)));
        //throw new System.NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        Debug.Log("status : " + string.Format("{0} is {1}, Msg : {2} ", user, status, message));
        //throw new System.NotImplementedException();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        Debug.Log("user : " + user);
        throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        Debug.Log("user : " + user);
        throw new System.NotImplementedException();
    }

    void Update()
    {
        chatClient.Service();
    }

    public void Input_OnEndEdit(string text)
    {
        if (chatClient.State == ChatState.ConnectedToFrontEnd)
        {
            chatClient.PublishMessage(currentChannelName, inputField.text);
            inputField.text = "";
        }
    }

}
