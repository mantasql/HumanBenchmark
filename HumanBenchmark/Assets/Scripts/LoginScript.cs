using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{
    SimpleDB simpleDB;

    void Start()
    {
        simpleDB = GameObject.Find("DatabaseManager").GetComponent<SimpleDB>();
    }

    public void LoginUser() 
    {
        string username = GameObject.Find("Username").GetComponentInChildren<TMP_InputField>().text;
        string password = GameObject.Find("Password").GetComponentInChildren<TMP_InputField>().text;

        if (simpleDB.VerifyLogin(username, password))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        Debug.Log(username);
        Debug.Log(password);
        //if (simpleDB.Use)

        //GetComponentInChildren<TMP_InputField>().text
    }
}
