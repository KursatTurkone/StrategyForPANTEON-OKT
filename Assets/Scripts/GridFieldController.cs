using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFieldController : MonoBehaviour
{
    
    GridController gridController;
    DragBuilding dragBuilding;
    Vector2 vector;
    private int value;   
    void Start()
    {
        GameObject gObj = GameObject.Find("GridController");
        gridController = (GridController)gObj.GetComponent(typeof(GridController));        
        GameObject obj = GameObject.Find("Square(Clone)");
        dragBuilding = (DragBuilding)obj.GetComponent(typeof(DragBuilding));
    }


    void Update()
    {    
        vector = transform.position;      
       value = gridController.getValue(vector);
        print(dragBuilding.dropped);
        if (value == 0)
        {
            if (!dragBuilding.dropped)
                gameObject.GetComponent<Renderer>().material.color = Color.blue;

            gameObject.transform.parent.position = new Vector2(-50, 200);
           
        }
        else if (value == 1)
        {
           
            if (dragBuilding.dropped)
              {                             
                gridController.setValue(vector);
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
        }
        else if (value == 2)
        {
         //   gameObject.GetComponent<Renderer>().material.color = Color.red;
            //kırmızıya çevir 
            if (dragBuilding.dropped)
            {
                //gameObject.transform.parent.position = new Vector2(-50,200) ;
            }
            else if(!dragBuilding.dropped)
            {
                print("girer");
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
   
}
