using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridController : MonoBehaviour
{
   new  GridMap grid;


    void Start()
    {
       

        grid  = new GridMap(16, 11,32.0f,new Vector3(0,64,0));
       

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
            print(UtilsClass.GetMouseWorldPosition());
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
    }

}

