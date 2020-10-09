using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils; 

public class CharacterMovement : MonoBehaviour
{
    private const float speed = 100f;
    private int currentPathIndex;
    private List<Vector3> pathVectorList;
 
    // Start is called before the first frame update
    void Start()
    {
        Transform soldier = transform.Find("soldier");
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition(UtilsClass.GetMouseWorldPosition());
        }

    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public void SetTargetPosition(Vector3 targetPosition)
    {
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