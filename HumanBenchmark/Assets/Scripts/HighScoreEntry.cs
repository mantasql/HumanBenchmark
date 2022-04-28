using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreEntry
{
    private int score;
    private string name;

    public int Score {get => score; set {score = value;}}
    public string Name {get => name; set {name = value;}}
}
