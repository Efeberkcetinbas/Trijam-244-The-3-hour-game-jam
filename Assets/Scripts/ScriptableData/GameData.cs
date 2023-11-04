using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData", order = 0)]
public class GameData : ScriptableObject 
{

    public int score;
    public int highscore;
    public int increaseScore;
    public int LevelRequirementNumber;
    public int ProgressNumber;
    public int LevelNumberIndex;

    public bool isGameEnd=false;

    
}
