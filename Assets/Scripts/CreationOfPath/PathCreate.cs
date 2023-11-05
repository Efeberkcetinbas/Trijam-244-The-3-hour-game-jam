using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathCreate : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private List<Vector3> points=new List<Vector3>();

    public Action<IEnumerable<Vector3>> OnNewPathCreated=delegate {};

    private Camera cam;

    public PlayerData playerData;
    public GameData gameData;

    void Start()
    {
        lineRenderer=GetComponent<LineRenderer>();
        cam=Camera.main;
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnLevelEnd,OnLevelEnd);

    }

    private void OnDisable() 
    {
        EventManager.AddHandler(GameEvent.OnLevelEnd,OnLevelEnd);
    }

    void Update()
    {
        if(!gameData.isGameEnd)
        {

        
            if(Input.GetButtonDown("Fire1"))
            {
                if(playerData.playerCanMove)
                {
                    points.Clear();
                    
                }

                if(!playerData.playerCanMove)
                {
                    gameData.isGameEnd=true;
                    //Event
                }
            }

           
                

            if(Input.GetButton("Fire1"))
            {
                Ray ray=cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if(Physics.Raycast(ray,out hitInfo))
                {
                    if(DistanceToLastPoint(hitInfo.point)>1f)
                    {
                        points.Add(hitInfo.point);
                        lineRenderer.positionCount=points.Count;
                        lineRenderer.SetPositions(points.ToArray());
                    }
                    
                }
            }

            else if(Input.GetButtonUp("Fire1"))
            {
                OnNewPathCreated(points);
                playerData.playerCanMove=false;
            }
        }
    }

    private void OnLevelEnd()
    {
        points.Clear();
        OnNewPathCreated(points);
        lineRenderer.positionCount=0;
    }

    private float DistanceToLastPoint(Vector3 point)
    {
        if(!points.Any())
            return Mathf.Infinity;
        
        return Vector3.Distance(points.Last(),point);
    }
}
