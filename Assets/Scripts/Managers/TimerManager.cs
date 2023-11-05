using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public GameData gameData;

    private void Update() 
    {
        gameData.timer+=Time.deltaTime;
        SetTimeClock();
        EventManager.Broadcast(GameEvent.OnUpdateTimeUI);
    }

    private void SetTimeClock()
    {
        gameData.minutes=Mathf.FloorToInt(gameData.timer/60f);
        gameData.seconds=Mathf.FloorToInt(gameData.timer-gameData.minutes*60);

        
    }
}
