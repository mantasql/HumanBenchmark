using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class DatabaseTests
{
    [Test]
    public void CreateNewUserTest()
    {
        SimpleDB simpleDB = GameObject.Find("DatabaseManager").GetComponent<SimpleDB>();
        string randomUsername = System.Guid.NewGuid().ToString();
        simpleDB.CreateUser(randomUsername, randomUsername);
        Assert.AreEqual(simpleDB.DoesUserExist(randomUsername), true);
    }
}
