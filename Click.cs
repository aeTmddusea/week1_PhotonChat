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
            Debug.Log("로그인 성공");
            SceneManager.LoadScene("ChatTest");
        }
        else
        {
            Debug.Log("로그인 실패");
            SceneManager.LoadScene("Authentication");
        }
    }
}
