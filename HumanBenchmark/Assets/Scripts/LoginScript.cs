using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{
    SimpleDB simpleDB;
    public GameObject SignInScreen;
    public GameObject SignUpScreen;


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
    }

    public void RegisterUser() 
    {
        string username = GameObject.Find("Username").GetComponentInChildren<TMP_InputField>().text;
        string password = GameObject.Find("Password").GetComponentInChildren<TMP_InputField>().text;
        string confirmPassword = GameObject.Find("ConfirmPassword").GetComponentInChildren<TMP_InputField>().text;

        if (confirmPassword != password) return;
        if (username.Length <= 0 || password.Length <= 0) return;

        if (simpleDB.CreateUser(username, password))
        {
            SignInScreen.SetActive(true);
            SignUpScreen.SetActive(false);
        }
    }
}
