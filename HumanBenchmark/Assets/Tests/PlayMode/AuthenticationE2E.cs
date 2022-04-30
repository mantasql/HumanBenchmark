using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AuthenticationE2E
{
    private void LoadScene()
    {
        SceneManager.LoadScene("Authentication");
    }


    [UnityTest]
    public IEnumerator BlankSignInTest()
    {
        LoadScene();
        yield return null;

        GameObject.Find("SignIn/SignIn").GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.AreEqual("Authentication",SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator SignInWithCredentialsTest()
    {
        LoadScene();
        yield return null;

        SimpleDB simpleDB = GameObject.Find("DatabaseManager").GetComponent<SimpleDB>();

        GameObject.Find("SignIn/Username").GetComponent<TMP_InputField>().text = "TestLogin";
        GameObject.Find("SignIn/Password").GetComponent<TMP_InputField>().text = "TestPassword";

        Assert.AreEqual(simpleDB.VerifyLogin("TestLogin","TestPassword"),true);

        GameObject.Find("SignIn/SignIn").GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.AreEqual("MainMenu",SceneManager.GetActiveScene().name);
    }
}
