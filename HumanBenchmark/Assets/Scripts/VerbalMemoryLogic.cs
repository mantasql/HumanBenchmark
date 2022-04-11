using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VerbalMemoryLogic : MonoBehaviour
{
    public TMP_Text displayedWord;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public TMP_Text correctWordCount;

    List<string> wordBank = new List<string> {"alarm", "allowance", "ancestor", "astonishing", "belief", "bow", "casualty", "central", "comfort", "control", "conversation", "dash", "digital", "distortion", "drag", "era", "execute", "explicit", "expose", "fascinate", "fossil", "goat", "hypothesize", "imagine", "justify", "learn", "lemon", "lie", "link", "majority", "miner", "moral", "negative", "node", "pedestrian", "performance", "prisoner", "recommend", "reconcile", "relation", "relevance", "representative", "row", "scene", "science", "suntan", "surround", "threaten", "trap", "tread"};

    List<string> showableWords = new List<string>();
    List<string> shownWords = new List<string>();
    string currentWord = null;

    private bool gameRunning;

    int currentWordIndex = 0;
    int correctAnswers = 0;

    void Start(){
        gameOverPanel.SetActive(false);
        gamePanel.SetActive(true);
        displayedWord.text = ShowRandomWord();
        gameRunning = true;
    }

    string ShowRandomWord()
    {
        string newShowableWord = wordBank[Random.Range(0, wordBank.Count)];
        showableWords.Add(newShowableWord);
        wordBank.Remove(newShowableWord);
        
        currentWord = showableWords[Random.Range(0, showableWords.Count)];
        
        currentWordIndex++;
        Debug.Log(currentWordIndex);
        return currentWord;
    }

    void ResetWords()
    {
        wordBank.AddRange(showableWords);
        showableWords.Clear();
        shownWords.Clear();
        currentWord = null;
    }

    public void OnSeenWordClick()
    {
        if(shownWords.Contains(currentWord) && wordBank.Count>0){
            displayedWord.text = ShowRandomWord();
            correctAnswers++;
        } else{
            gameRunning = false;
            showGameOverScreen(); 
        }
    }

    public void OnNewWordClick()
    {
        if(!shownWords.Contains(currentWord) && wordBank.Count>0){
            shownWords.Add(currentWord);
            displayedWord.text = ShowRandomWord();   
            correctAnswers++;
        } else{
            gameRunning = false;
            showGameOverScreen();
        }
    }

    private void showGameOverScreen(){
        correctWordCount.text = "Correct word count: "+ correctAnswers;
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void restartGame(){
        ResetWords();
        currentWordIndex = 0;
        correctAnswers = 0;
        gamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }
}
