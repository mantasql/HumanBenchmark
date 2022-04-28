using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScoreTable : MonoBehaviour
{

    private int score;
    private string userName;

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransfromList;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        highScoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry{Score = 20315, Name="User1"},
            new HighScoreEntry{Score = 1546, Name="User2"},
            new HighScoreEntry{Score = 15645, Name="User3"},
            new HighScoreEntry{Score = 4515, Name="User4"},
            new HighScoreEntry{Score = 15612, Name="User5"},
            new HighScoreEntry{Score = 56565, Name="User6"},
            new HighScoreEntry{Score = 2155, Name="User7"},
            new HighScoreEntry{Score = 564, Name="User8"},
            new HighScoreEntry{Score = 5896, Name="User9"},
            new HighScoreEntry{Score = 5656, Name="Arunasd"},
        };

        sortLeaderboard(highScoreEntryList);

        highScoreEntryTransfromList = new List<Transform>();
        foreach(HighScoreEntry highScoreEntry in highScoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransfromList);
        }
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 60f;

        Transform entryTransform = Instantiate(entryTemplate,container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight*transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int position = 1+transformList.Count;
        score = highScoreEntry.Score;
        userName = highScoreEntry.Name;

        entryTransform.Find("PosHeader").GetComponent<TMP_Text>().text = position.ToString();
        entryTransform.Find("NameHeader").GetComponent<TMP_Text>().text = userName;
        entryTransform.Find("ScoreHeader").GetComponent<TMP_Text>().text = score.ToString();

        transformList.Add(entryTransform);
    }

    public void sortLeaderboard(List<HighScoreEntry> highScoreEntryList)
    {
        for(int i=0;i<highScoreEntryList.Count;i++)
        {
            for(int j=i+1;j<highScoreEntryList.Count;j++)
            {
                if(highScoreEntryList[j].Score > highScoreEntryList[i].Score)
                {
                    HighScoreEntry tmp = highScoreEntryList[i];
                    highScoreEntryList[i] = highScoreEntryList[j];
                    highScoreEntryList[j] = tmp;
                }
            }
        }
    }

    public void returnToPreviousScene()
    {

    }
}
