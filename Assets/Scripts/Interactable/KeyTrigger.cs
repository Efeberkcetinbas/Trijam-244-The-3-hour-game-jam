using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : Obstacleable
{
    [SerializeField] private GameObject destroyEffect;
    internal override void DoAction(Player player)
    {
        Instantiate(destroyEffect,transform.position,Quaternion.identity);
        EventManager.Broadcast(GameEvent.OnCollectKey);
        Destroy(gameObject);
    }
}
