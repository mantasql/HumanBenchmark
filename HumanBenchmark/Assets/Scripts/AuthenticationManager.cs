using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AuthenticationManager : MonoBehaviour
{
    public static string signedInEmail;

    public GameObject signInPanel;
    public TMP_InputField signInEmail;
    public TMP_InputField signInPassword;

    public GameObject signUpPanel;
    public TMP_InputField signUpEmail;
    public TMP_InputField signUpPassword;
    public TMP_InputField signUpConfirmPassword;
    
    public void OpenSignUp()
    {
        signInPanel.SetActive(false);
        signUpPanel.SetActive(true);
    }

    public void OpenSignIn()
    {
        signUpPanel.SetActive(false);
        signInPanel.SetActive(true);
    }
}
