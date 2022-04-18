using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;

public class VerbalMemoryEditModeTests
{
    [Test]
    public void ShowsFirstWord()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/VerbalMemoryGame.unity");
        VerbalMemoryLogic verbalMemoryLogic = GameObject.Find("VerbalMemoryLogic").GetComponent<VerbalMemoryLogic>();
        verbalMemoryLogic.ShowRandomWord();
        Assert.AreEqual(true, verbalMemoryLogic.getCurrentWord() != null);
    }

    [Test]
    public void GameOverScreenTest()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/VerbalMemoryGame.unity");
        VerbalMemoryLogic verbalMemoryLogic = GameObject.Find("VerbalMemoryLogic").GetComponent<VerbalMemoryLogic>();
        verbalMemoryLogic.showGameOverScreen();
        GameObject gameOverScreen = GameObject.Find("GameOverPanel");
        Assert.AreEqual(true, gameOverScreen.active);
    }

    [Test]
    public void WordBankTest()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/VerbalMemoryGame.unity");
        VerbalMemoryLogic verbalMemoryLogic = GameObject.Find("VerbalMemoryLogic").GetComponent<VerbalMemoryLogic>();
        verbalMemoryLogic.ResetWords();
        Assert.AreEqual(true, verbalMemoryLogic.getWordBankSize() >= 50);
    }
}
