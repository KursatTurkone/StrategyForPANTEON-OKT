using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using Assets.Scripts;

public class CharacterMovement : MonoBehaviour
{
    private const float speed = 100f;
    private int currentPathIndex;
    private List<Vector3> pathVectorList;
    PickObjects dragBuilding;
    private IEnumerator coroutine;
    bool wait = false; 

    void Start()
    {      
        //coroutine for character 
        coroutine = WaitAndStart(0.5f);
        StartCoroutine(coroutine); 
        Transform soldier = transform.Find("soldier");     
        GameObject drg = GameObject.Find("Main Camera");
        dragBuilding = (PickObjects)drg.GetComponent(typeof(PickObjects));
    }
    private IEnumerator WaitAndStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);    
        wait = true;       
    }


    [System.Obsolete]
    void Update()
    {      
        HandleMovement();
        if (Input.GetMouseButtonDown(0)&&dragBuilding.characterSelected&&wait)
        {
            //getLocation to move 
            SetTargetPosition(UtilsClass.GetMouseWorldPosition());
        }
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public void SetTargetPosition(Vector3 targetPosition)
    {
        //setLocation to move 
        currentPathIndex = 0;
        pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), targetPosition);
        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
    }
    private void HandleMovement()
    {
        if (pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(transform.position, targetPosition) > 1f)
            {
                Vector3 moveDir = (targetPosition - transform.position).normalized;

                float distanceBefore = Vector3.Distance(transform.position, targetPosition);

                transform.position = transform.position + moveDir * speed * Time.deltaTime;
            }
            else
            {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();
                }
            }
        }
      
        
       
    }
    private void StopMoving()
    {
        pathVectorList = null;
    }
}