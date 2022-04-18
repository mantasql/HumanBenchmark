using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ReactionTimeGameTests
{
    [UnityTest]
    public IEnumerator When_BackToMenuIsClicked_Expect_ActiveSceneIsMainMenu()
    {
        GameObject gameObject = new GameObject();
        BackToMenuButton backToMenuButton = gameObject.AddComponent<BackToMenuButton>();
        yield return null;
        backToMenuButton.OnClick();
        yield return null;
        Assert.True(SceneManager.GetSceneByName("MainMenu").isLoaded);
    }

    [UnityTest]
    public IEnumerator When_ClickedToStart_Expect_GameIsRunning()
    {
        GameObject gameObject = new GameObject();
        ReactionTimeGame reactionTimeGame = gameObject.AddComponent<ReactionTimeGame>();
        yield return null;
        reactionTimeGame.OnClick();
        yield return null;
        Assert.True(reactionTimeGame.IsGameRunning());
    }

    [UnityTest]
    public IEnumerator When_ClickedAfterStart_Expect_GameIsNotRunning()
    {
        GameObject gameObject = new GameObject();
        ReactionTimeGame reactionTimeGame = gameObject.AddComponent<ReactionTimeGame>();
        yield return null;
        reactionTimeGame.OnClick();
        yield return null;
        reactionTimeGame.OnClick();
        yield return null;
        Assert.False(reactionTimeGame.IsGameRunning());
    }
}
