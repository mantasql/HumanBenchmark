using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using TMPro;

public class SignUpE2E
{
    [UnityTest]
    public IEnumerator OpenCloseSignUpTest()
    {
        SceneManager.LoadScene("Authentication");
        yield return null;

        GameObject.Find("Canvas/Background/SignIn/SignUp").GetComponent<Button>().onClick.Invoke();
        yield return null;

        GameObject.Find("Canvas/Background/SignUp/Cancel").GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.IsFalse(GameObject.Find("Canvas/Background/SignUp").activeSelf);
    }

    [UnityTest]
    public IEnumerator BlankSignUpTest()
    {
        SceneManager.LoadScene("Authentication");
        yield return null;

        GameObject.Find("Canvas/Background/SignIn/SignUp").GetComponent<Button>().onClick.Invoke();
        yield return null;

        GameObject.Find("Canvas/Background/SignUp/SignUp").GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.IsTrue(GameObject.Find("Canvas/Background/SignUp").activeSelf);
    }

    [UnityTest]
    public IEnumerator SignUpTest()
    {
        SceneManager.LoadScene("Authentication");
        yield return null;

        GameObject.Find("Canvas/Background/SignIn/SignUp").GetComponent<Button>().onClick.Invoke();
        yield return null;

        string username = System.Guid.NewGuid().ToString();
        GameObject.Find("Canvas/Background/SignUp/Username/Text Area/Text").GetComponent<TMP_Text>().text = username;
        GameObject.Find("Canvas/Background/SignUp/Password/Text Area/Text").GetComponent<TMP_Text>().text = username;
        GameObject.Find("Canvas/Background/SignUp/ConfirmPassword/Text Area/Text").GetComponent<TMP_Text>().text = username;

        GameObject.Find("Canvas/Background/SignUp/SignUp").GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.IsFalse(GameObject.Find("Canvas/Background/SignUp").activeSelf);
    }
}