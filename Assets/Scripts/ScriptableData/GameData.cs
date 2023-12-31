using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData", order = 0)]
public class GameData : ScriptableObject 
{

    public int score;
    public int highscore;
    public int increaseScore;
    public float LevelRequirementNumber;
    public float sumReqNumber;
    public float ProgressNumber;
    
    //Timer
    public float timer;
    public int minutes;
    public int seconds;

    public string ShowTime;

    public bool isGameEnd=false;

    
}
