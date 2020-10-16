using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFieldController : MonoBehaviour
{
    bool isDropped=true;
    GridController gridController;
    DragBuilding dragBuilding;
    Vector2 vector;
    private int value;
    public int sortingOrder = 3;
    private SpriteRenderer sprite;
    void Start()
    {
        GameObject gObj = GameObject.Find("GridController");
        gridController = (GridController)gObj.GetComponent(typeof(GridController));
        //    GameObject obj = GameObject.Find("Square(Clone)");
        GameObject obj = GameObject.Find("Square(Clone)");
        dragBuilding = (DragBuilding)obj.GetComponent(typeof(DragBuilding));

        sprite = GetComponent<SpriteRenderer>(); 
    }

    void drop()
    {
        isDropped=true;
    }
    void Update()
    {    
        vector = transform.position;      
       value = gridController.getValue(vector);
      
        if (value == 0)
        {
            if (!dragBuilding.dropped)
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
            gameObject.transform.parent.position = new Vector2(-50, 200);
           
        }
        else if (value == 1)
        {
           
            if (dragBuilding.dropped&& isDropped)
              {
                sprite.sortingOrder = 1;
                this.gameObject.name = "Placed";
                this.gameObject.tag = "building";
                //when dropped change object name so it can't move anymore
                gridController.setValue(vector);
                this.gameObject.GetComponent<Renderer>().material.color = Color.white;
                isDropped = false;                              
            }
            else
            {
                this.gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
        }
        else if (value == 2)
        {
        
            if (dragBuilding.dropped&&isDropped)
            {                
                Destroy(transform.parent.gameObject);
            }
            else if(!dragBuilding.dropped)
            {              
                this.gameObject.GetComponent<Renderer>().material.color = Color.red;
                sprite.sortingOrder = 2;
                
            }
        }
    }
   
}
