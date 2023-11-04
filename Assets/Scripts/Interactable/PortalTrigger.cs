using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : Obstacleable
{
    internal override void DoAction(Player player)
    {
        EventManager.Broadcast(GameEvent.OnNextLevel);
    }
}
