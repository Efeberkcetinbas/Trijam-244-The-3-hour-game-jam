using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score,highscore,endingScore;

    public GameData gameData;
    public PlayerData playerData;

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnUIUpdate, OnUIUpdate);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnUIUpdate, OnUIUpdate);
    }

    
    void OnUIUpdate()
    {
        score.SetText(gameData.score.ToString());
        score.transform.DOScale(new Vector3(1.5f,1.5f,1.5f),0.2f).OnComplete(()=>score.transform.DOScale(new Vector3(1,1f,1f),0.2f));
    }

    
}
