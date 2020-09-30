using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    Transform transform;
   public GridMap grid;
    int gridValue;
   
    private void Start()
    {
        
    }
    private void Update()
    {
       gridValue=  grid.GetValue((int)transform.position.x,(int)transform.position.y);
        if (gridValue == 0)
        {
            //koyulabilir olacak
        }
        else
        {
            //değen yeri kırmızı yap
        }
      

    }




















}










/* public GameObject target;
    public GameObject structure;
    Vector2 truePos;
    private float gridSize=32;
    void LateUpdate()
    {
       
        truePos.x = Mathf.Floor(target.transform.position.x/gridSize) * (gridSize) + (gridSize / 2);
       truePos.y = Mathf.Floor(target.transform.position.y/gridSize) * (gridSize) + (gridSize / 2);   
        structure.transform.position = truePos;
    }*/