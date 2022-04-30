using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class VerbalMemoryE2E
{
    [UnityTest]
    public IEnumerator CorrectChoice()
    {
        SceneManager.LoadScene("VerbalMemoryGame");
        yield return null;

        GameObject gamePanel = GameObject.Find("GamePanel");
        Assert.AreEqual(true, gamePanel.activeSelf);
        yield return null;

        string currentWord = gamePanel.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text;
        GameObject newWordButton = gamePanel.transform.Find("NewButton").gameObject;
        newWordButton.GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.AreEqual(true, gamePanel.activeSelf);
    }

    [UnityTest]
    public IEnumerator WrongChoice()
    {
        SceneManager.LoadScene("VerbalMemoryGame");
        yield return null;

        GameObject gamePanel = GameObject.Find("GamePanel");
        Assert.AreEqual(true, gamePanel.activeSelf);
        yield return null;
    
        string currentWord = gamePanel.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text;
        GameObject seenButton = gamePanel.transform.Find("SeenButton").gameObject;
        seenButton.GetComponent<Button>().onClick.Invoke();
        yield return null;
        
        Assert.AreEqual(false, gamePanel.activeSelf);
    }

    [UnityTest]
    public IEnumerator ReturnToMenu()
    {
        SceneManager.LoadScene("VerbalMemoryGame");
        yield return null;

        GameObject.Find("Canvas").transform.Find("Button").GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.AreEqual("MainMenu", SceneManager.GetActiveScene().name); 
    }
}
