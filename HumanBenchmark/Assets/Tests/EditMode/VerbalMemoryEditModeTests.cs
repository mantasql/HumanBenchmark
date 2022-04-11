using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class VerbalMemoryEditModeTests
{
    [Test]
    public void ShowsFirstWord()
    {
        VerbalMemoryLogic verbalMemoryLogic = GameObject.Find("VerbalMemoryLogic").GetComponent<VerbalMemoryLogic>();
        verbalMemoryLogic.ShowRandomWord();
        Assert.AreEqual(true, verbalMemoryLogic.getCurrentWord() != null);
    }

    [Test]
    public void GameOverScreenTest()
    {
        VerbalMemoryLogic verbalMemoryLogic = GameObject.Find("VerbalMemoryLogic").GetComponent<VerbalMemoryLogic>();
        verbalMemoryLogic.showGameOverScreen();
        GameObject gameOverScreen = GameObject.Find("GameOverPanel");
        Assert.AreEqual(true, gameOverScreen.active);
    }

    [Test]
    public void WordBankTest()
    {
        VerbalMemoryLogic verbalMemoryLogic = GameObject.Find("VerbalMemoryLogic").GetComponent<VerbalMemoryLogic>();
        verbalMemoryLogic.ResetWords();
        Assert.AreEqual(true, verbalMemoryLogic.getWordBankSize() >= 50);
    }
}
