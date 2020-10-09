using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickButtons : MonoBehaviour
{
 private   BuildingCreator creator;
    string nameOfBuilding;
  public  bool changed; 
   
    private void Start()
    {
        GameObject bc = GameObject.Find("BuildCreator");
         creator = (BuildingCreator)bc.GetComponent(typeof(BuildingCreator));     
        changed = true; 
    }
    public void Onclick()
    {      
        if (changed)
        {           
            nameOfBuilding = EventSystem.current.currentSelectedGameObject.name;
            creator.createBuilding(nameOfBuilding);
            changed = false;          
        }
    }
 public void changeState()
    {
        changed = true;
    }

}
