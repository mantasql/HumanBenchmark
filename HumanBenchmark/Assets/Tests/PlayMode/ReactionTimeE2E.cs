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
    private ReactionTimeGame reactionTimeGame;

    [UnityTest]
    public IEnumerator When_ClickReactionTimeGameButton_Expect_LoadReactionTimeGame()
    {
        SceneManager.LoadScene("MainMenu");
        yield return null;

        GameObject.Find("ReactionTimeUIButton").GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.AreEqual("ReactionTimeGame",SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator When_ClickGameStartButton_Expect_StartTheGame()
    {
        SceneManager.LoadScene("ReactionTimeGame");
        yield return null;

        reactionTimeGame = GameObject.Find("ClickArea").GetComponent<ReactionTimeGame>();

        GameObject.Find("ClickArea").GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.AreEqual(true,reactionTimeGame.IsGameRunning());
    }

    [UnityTest]
    public IEnumerator When_PressGameWindowWhenItsRed_Expect_GameToEnd()
    {
        SceneManager.LoadScene("ReactionTimeGame");
        yield return null;
        
        reactionTimeGame = GameObject.Find("ClickArea").GetComponent<ReactionTimeGame>();

        GameObject.Find("ClickArea").GetComponent<Button>().onClick.Invoke();
        yield return null;

        GameObject.Find("ClickArea").GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.AreEqual(false,reactionTimeGame.IsGameRunning());
    }    

    [UnityTest]
    public IEnumerator When_PressRestartButton_Expect_StartGame()
    {
        SceneManager.LoadScene("ReactionTimeGame");
        yield return null;

        reactionTimeGame = GameObject.Find("ClickArea").GetComponent<ReactionTimeGame>();

        GameObject.Find("ClickArea").GetComponent<Button>().onClick.Invoke();
        yield return null;

        GameObject.Find("ClickArea").GetComponent<Button>().onClick.Invoke();
        yield return null;

        GameObject.Find("ClickArea").GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.AreEqual(true,reactionTimeGame.IsGameRunning());
    }

    [UnityTest]
    public IEnumerator When_WaitForWindowToTurnGreen_Expect_TimerCanBeStopped()
    { 
        SceneManager.LoadScene("ReactionTimeGame");
        yield return null;

        GameObject.Find("ClickArea").GetComponent<Button>().onClick.Invoke();
        yield return null;

        reactionTimeGame = GameObject.Find("ClickArea").GetComponent<ReactionTimeGame>();
        yield return new WaitForSeconds(6);
        Assert.AreEqual(true,reactionTimeGame.TimerCanBeStopped);
    }   

    [UnityTest]
    public IEnumerator When_PressGameWindowWhenItsGreen_Expect_GameToEnd()
    { 
        SceneManager.LoadScene("ReactionTimeGame");
        yield return null;

        GameObject.Find("ClickArea").GetComponent<Button>().onClick.Invoke();
        yield return null;

        reactionTimeGame = GameObject.Find("ClickArea").GetComponent<ReactionTimeGame>();
        yield return new WaitForSeconds(6);

        GameObject.Find("ClickArea").GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.AreEqual(false,reactionTimeGame.IsGameRunning());
    }

    [UnityTest]
    public IEnumerator When_BackButtonIsPressed_Expect_LoadMainMenu()
    { 
        SceneManager.LoadScene("ReactionTimeGame");
        yield return null;

        GameObject.Find("BackToMenu").GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.AreEqual("MainMenu",SceneManager.GetActiveScene().name); 
    }

}
