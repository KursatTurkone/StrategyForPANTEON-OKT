using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickButtons : MonoBehaviour
{
    
 private   BuildingCreator creator;
    DragBuilding dragBuilding;
    string nameOfBuilding;
  public  bool changed; 
   
    private void Start()
    {
        changed = true;
        GameObject drg = GameObject.Find("Square(Clone)");
        if(drg!=null)
        dragBuilding = (DragBuilding)drg.GetComponent(typeof(DragBuilding));
    }
    public void Onclick()
    {      
        if (changed)
        {           
                nameOfBuilding = EventSystem.current.currentSelectedGameObject.name;          
            CreatePub.OnClickFunction(nameOfBuilding);
                changed = false;               
        }
    }
  
    public void changeState()
    {
        changed = true;
    }

}
