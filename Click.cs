using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    public InputField ID;
    public InputField PW;
    public Button LoginButton;

    public void LoginButtonClick()
    {
        if (ID.text == "User" && PW.text == "1234")
        {
            Debug.Log("�α��� ����");
            SceneManager.LoadScene("ChatTest");
        }
        else
        {
            Debug.Log("�α��� ����");
            SceneManager.LoadScene("Authentication");
        }
    }
}
