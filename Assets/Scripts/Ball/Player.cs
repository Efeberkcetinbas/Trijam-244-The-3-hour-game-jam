using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.AddHandler(GameEvent.OnCollectKey,OnCollectKey);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.RemoveHandler(GameEvent.OnCollectKey,OnCollectKey);
    }

    private void OnNextLevel()
    {
        transform.position=Vector3.zero;
    }

    private void OnCollectKey()
    {
        transform.DOScale(Vector3.one*1.5f,0.25f).OnComplete(()=>transform.DOScale(Vector3.one,0.25f));
    }
}
