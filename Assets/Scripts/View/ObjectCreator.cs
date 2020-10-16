using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField]
    GameObject Unit;
    int divH, divW;
    float locationX, locationY;
    float[,] trys;
    Vector2 tryLoc;
    int cellSize = 32;
    Vector3 vector;
    Vector3[] vectors; 
    GridController gridController;
    int counter=0;
    string name; 
    private void Start()
    {
        GameObject gObj = GameObject.Find("GridController");
        gridController = (GridController)gObj.GetComponent(typeof(GridController));                   
    }
    public void buildingLocation(Vector3 vector)
    {
        this.vector = vector;
    }
    public void lengthGetter(int height, int weight)
    {            
        float yedekx, yedeky;
        bool check=true; 
     
        float divH, divW;
        float cellSize = gridController.getpixel();
        float cellSize2 = cellSize;

        divH = cellSize / height;
        divW = cellSize / weight;
        for (int i = 0; i < weight; i++)
        {
            divH = -divH;
            for (int j = 0; j < height; j++)
            {
                divW = -divW;
                yedekx = vector.x + divH;
                yedeky = vector.y + divW;
                tryLoc.x = yedekx - cellSize;
                tryLoc.y = yedeky;
                if (gridController.getValue(tryLoc) == 1&&check)
                {

                    Unit.name="Character"+counter;
                    counter++;
                    Instantiate(Unit,tryLoc,Quaternion.identity);
                    check = false; 
                    break; 

                }
                tryLoc.x = yedekx;
                tryLoc.y = yedeky - cellSize2;
                if (gridController.getValue(tryLoc) == 1&&check)
                {
                    Unit.name = name + counter;
                    counter++;
                    check = false;
                    Instantiate(Unit, tryLoc, Quaternion.identity);
                    break;

                }

                cellSize2 = -cellSize2;
            }
            cellSize = -cellSize;
        }           
                }
     
    }
