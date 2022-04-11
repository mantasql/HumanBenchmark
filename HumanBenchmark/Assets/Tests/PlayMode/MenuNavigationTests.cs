using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigationTests
{
    private void LoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    [UnityTest]
    public IEnumerator LoadVerbalMemoryGame()
    {
        LoadScene();
        yield return null;

        GameObject.Find("VerbalMemoryUIButton").GetComponent<Button>().onClick.Invoke();

        yield return null;

        Assert.AreEqual("VerbalMemoryGame",SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator LoadReactionTimeGame()
    {
        LoadScene();
        yield return null;

        GameObject.Find("ReactionTimeUIButton").GetComponent<Button>().onClick.Invoke();

        yield return null;

        Assert.AreEqual("ReactionTimeGame",SceneManager.GetActiveScene().name);
    }
}
