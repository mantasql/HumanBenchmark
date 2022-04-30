using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ReactionTimeE2E
{
    private void LoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    [UnityTest]
    public IEnumerator ReactionTimeGame()
    {

        LoadScene();
        yield return null;

        GameObject.Find("ReactionTimeUIButton").GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.AreEqual("ReactionTimeGame",SceneManager.GetActiveScene().name);

        ReactionTimeGame reactionTimeGame = GameObject.Find("ClickArea").GetComponent<ReactionTimeGame>();

        GameObject.Find("ClickArea").GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.AreEqual(true,reactionTimeGame.IsGameRunning());

        GameObject.Find("ClickArea").GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.AreEqual(false,reactionTimeGame.IsGameRunning());

        GameObject.Find("ClickArea").GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.AreEqual(true,reactionTimeGame.IsGameRunning());

        yield return new WaitForSeconds(6);

        Assert.AreEqual(true,reactionTimeGame.TimerCanBeStopped);
        GameObject.Find("ClickArea").GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.AreEqual(false,reactionTimeGame.IsGameRunning());

        GameObject.Find("BackToMenu").GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.AreEqual("MainMenu",SceneManager.GetActiveScene().name); 
    }
}
