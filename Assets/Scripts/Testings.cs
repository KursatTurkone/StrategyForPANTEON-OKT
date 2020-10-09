using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class Testings : MonoBehaviour
{
    private Pathfinding pathfinding;
   private GridMap gridMap; 
   private Grids<int> grid;
  
  [SerializeField]  private CharacterMovement characterMovement;  
    
    void Start()
    {
       gridMap = new GridMap(10,10,10,Vector3.zero);
       gridMap.SetValue(0,0,1);
         //pathfinding = new Pathfinding(10,10); 

    }
  
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
             gridMap.SetValue(UtilsClass.GetMouseWorldPosition(), 2);
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            if (path != null)
            {               
                characterMovement.SetTargetPosition(mouseWorldPosition);
            }
            
        }
        if (Input.GetMouseButtonDown(1))
        {
         
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            
            Debug.Log(gridMap.GetValue(UtilsClass.GetMouseWorldPosition()));
            pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);
           
        }
    }
    }

