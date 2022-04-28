using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;

public class DatabaseTests
{
    [UnityTest]
    public IEnumerator CreateNewUserTest()
    {
        EditorSceneManager.LoadScene("Assets/Scenes/Authentication.unity");
        yield return null;
        SimpleDB simpleDB = GameObject.Find("DatabaseManager").GetComponent<SimpleDB>();
        string randomUsername = System.Guid.NewGuid().ToString();
        simpleDB.CreateUser(randomUsername, randomUsername);
        Assert.AreEqual(simpleDB.DoesUserExist(randomUsername), true);
        yield return null;
    }

    [UnityTest]
    public IEnumerator LoginTest()
    {
        EditorSceneManager.LoadScene("Assets/Scenes/Authentication.unity");
        yield return null;
        SimpleDB simpleDB = GameObject.Find("DatabaseManager").GetComponent<SimpleDB>();
        string randomUsername = System.Guid.NewGuid().ToString();
        simpleDB.CreateUser(randomUsername, randomUsername);
        simpleDB.VerifyLogin(randomUsername, randomUsername);
        Assert.AreEqual(randomUsername, PlayerPrefs.GetString("loggedInUser"));
        yield return null;
    } 
}