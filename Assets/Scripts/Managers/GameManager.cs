using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [Header("Scriptable Data's")]
    public GameData gameData;
    public PlayerData playerData;

    //Level Progress


    [Header("Game Ending")]

    //Bir Canvas‘ı gizlemek için SetActive(false) yerine enabled=false‘u tercih edin
    public GameObject failPanel;


    [Header("Open/Close")]
    [SerializeField] private GameObject[] open_close;



    private void Awake() 
    {
        ClearData();
    }
    

    

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnNextLevel,OnNextLevel);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnNextLevel,OnNextLevel);
    }


    #region LEVEL PROPERTIES

    //When Level Change Update Req Ball Pass Number
    private void UpdateRequirement()
    {
        gameData.LevelRequirementNumber=FindObjectOfType<RequirementControl>().RequirementNumber;
        EventManager.Broadcast(GameEvent.OnUIRequirementUpdate);
        //Update UI
    }

   

    #endregion



    void OnGameOver()
    {
        failPanel.SetActive(true);
        playerData.playerCanMove=false;
        gameData.isGameEnd=true;
    }
    private void OnNextLevel()
    {
        gameData.ProgressNumber=0;
        gameData.isGameEnd=true;
        EventManager.Broadcast(GameEvent.OnUIRequirementUpdate);
    }

    private void OnGameStart()
    {
        UpdateRequirement();
    }

    
    
    void ClearData()
    {
        gameData.isGameEnd=true;
        gameData.ProgressNumber=0;
    }

   

    public void OpenFailMenu()
    {
        failPanel.SetActive(true);
        failPanel.transform.DOScale(Vector2.one*1.15f,0.5f).OnComplete(()=> {
            failPanel.transform.DOScale(Vector2.one,0.5f);
        });
    }

    public void OpenClose(GameObject[] gameObjects,bool canOpen)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if(canOpen)
                gameObjects[i].SetActive(true);
            else
                gameObjects[i].SetActive(false);
        }
    }

    
}
