using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class LeaderboardTests : MonoBehaviour
{
    [Test]
    public void SortLeaderboardTest()
    {
        HighScoreTable highScoreTable = new HighScoreTable();
        List<HighScoreEntry> highScoreEntryList;

        highScoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry{Score = 20315, Name="User1"},
            new HighScoreEntry{Score = 1546, Name="User2"},
            new HighScoreEntry{Score = 15645, Name="User3"},
        };

        highScoreTable.sortLeaderboard(highScoreEntryList);

        Assert.AreEqual(20315,highScoreEntryList[0].Score);
        Assert.AreEqual(15645,highScoreEntryList[1].Score);
        Assert.AreEqual(1546,highScoreEntryList[2].Score);
    }
}
