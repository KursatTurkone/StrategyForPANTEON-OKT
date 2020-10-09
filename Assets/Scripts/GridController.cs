using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridController : MonoBehaviour
{
    private Pathfinding pathfinding;
    new  GridMap grid;
    [SerializeField]
    int weight, height;
    [SerializeField]
    float pixelSize;
    [SerializeField]
    Vector3 vector; 
  


    void Start()
    {
       

        grid  = new GridMap(weight, height,pixelSize,vector);
        pathfinding = new Pathfinding(weight, height,pixelSize,vector);

        for (int x = 0; x < 16; x++)
        {

            for (int y = 0; y < 11; y++)
            {

                grid.SetValue(x, y, 1);
            }
        }

    }

 
    void Update()
    {
      
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        
        }

        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 2);
         
        }
    }
    public int getValue(Vector2 vector)
    {
        int value; 
       value=  grid.GetValue(vector);
        
        return value;
    }
    public void setValue(Vector2 vector)
    {
       
       grid.SetValue(vector,2);     
        pathfinding.GetGrid().GetXY(vector, out int x, out int y);
        pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);


    }
    public float getpixel()
    {
        return pixelSize; 

    }

}

