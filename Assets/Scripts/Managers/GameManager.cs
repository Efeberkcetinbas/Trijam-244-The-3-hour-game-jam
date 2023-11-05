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

    private float value;

    



    private void Awake() 
    {
        ClearData();
    }
    

    private void Start() 
    {
        //Bullshit Solution But I have to sleep. So Its temp
        Invoke("SetStartValues",1);
    }

    private void SetStartValues()
    {
        OnNextLevel();
    }

    

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnLevelEnd,OnLevelEnd);
        EventManager.AddHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.AddHandler(GameEvent.OnCollectKey,OnCollectKey);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnLevelEnd,OnLevelEnd);
        EventManager.RemoveHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.RemoveHandler(GameEvent.OnCollectKey,OnCollectKey);
    }


    #region LEVEL PROPERTIES

    //When Level Change Update Req Ball Pass Number
    private void UpdateRequirement()
    {
        gameData.LevelRequirementNumber=FindObjectOfType<RequirementControl>().RequirementNumber;
        EventManager.Broadcast(GameEvent.OnUIRequirementUpdate);
        value=1/gameData.LevelRequirementNumber;

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
        gameData.sumReqNumber=0;
        gameData.isGameEnd=false;
        playerData.playerCanMove=true;
        UpdateRequirement();
        EventManager.Broadcast(GameEvent.OnUIRequirementUpdate);
        

    }

    private void OnCollectKey()
    {
        EventManager.Broadcast(GameEvent.OnIncreaseScore);
        gameData.sumReqNumber++;
        gameData.ProgressNumber+=value;
        EventManager.Broadcast(GameEvent.OnUIRequirementUpdate);

        if(gameData.sumReqNumber==gameData.LevelRequirementNumber)
            EventManager.Broadcast(GameEvent.OnLevelEnd);
    }

    private void OnLevelEnd()
    {
        gameData.isGameEnd=true;
        
        StartCoroutine(CallOnNextLevel());
    }

    private IEnumerator CallOnNextLevel()
    {
        yield return new WaitForSeconds(2);
        EventManager.Broadcast(GameEvent.OnNextLevelStart);
    }
    
    
    void ClearData()
    {
        gameData.isGameEnd=false;
        gameData.sumReqNumber=0;
        gameData.ProgressNumber=0;
        playerData.playerCanMove=true;
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
