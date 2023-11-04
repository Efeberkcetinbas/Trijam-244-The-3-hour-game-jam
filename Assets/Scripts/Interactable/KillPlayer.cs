using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : Obstacleable
{
    public GameData gameData;
    internal override void DoAction(Player player)
    {
        gameData.isGameEnd=true;
        Debug.Log("DEAD PLAYER");
        //Event
        //
    }
}
