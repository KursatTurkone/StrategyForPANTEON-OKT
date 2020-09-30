using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickButtons : MonoBehaviour
{
 public   BuildingCreator creator;
    string nameOfBuilding;
    [SerializeField]
    GameObject blockField;
    private void Start()
    {
        GameObject ho = GameObject.Find("BuildCreator");
         creator = (BuildingCreator)ho.GetComponent(typeof(BuildingCreator));
       
       
    }
    public void Onclick()
    {       
           nameOfBuilding= EventSystem.current.currentSelectedGameObject.name;
         creator.createBuilding(nameOfBuilding);
    }

}
