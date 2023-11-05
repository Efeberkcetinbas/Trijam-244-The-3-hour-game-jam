using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Text's")]
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI highscore;
    [SerializeField] private TextMeshProUGUI timerText;

    public GameData gameData;
    public PlayerData playerData;

    [Header("Image's")]
    [SerializeField] private Image progressBar;

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnUIUpdate, OnUIUpdate);
        EventManager.AddHandler(GameEvent.OnUpdateTimeUI, OnUpdateTimeUI);
        EventManager.AddHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.AddHandler(GameEvent.OnUIRequirementUpdate,OnUIRequirementUpdate);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnUIUpdate, OnUIUpdate);
        EventManager.RemoveHandler(GameEvent.OnUpdateTimeUI, OnUpdateTimeUI);
        EventManager.RemoveHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.RemoveHandler(GameEvent.OnUIRequirementUpdate,OnUIRequirementUpdate);
    }

    private void Start() 
    {
        OnNextLevel();
        OnUIUpdate();
    }

    private void OnUpdateTimeUI() 
    {
        timerText.SetText(gameData.ShowTime=string.Format("{0:00} : {1:00}",gameData.minutes,gameData.seconds));
    }
    
    void OnUIUpdate()
    {
        //HighScore Tutucaz
        score.SetText(gameData.score.ToString());
        score.transform.DOScale(new Vector3(1.5f,1.5f,1.5f),0.2f).OnComplete(()=>score.transform.DOScale(new Vector3(1,1f,1f),0.2f));
    }

    private void OnUIRequirementUpdate()
    {
        progressBar.DOFillAmount(gameData.ProgressNumber,0.25f);
    }

    private void OnNextLevel()
    {
        progressBar.DOFillAmount(0,0.1f);
    }

    
}
