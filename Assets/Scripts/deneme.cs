using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    class deneme : MonoBehaviour

    {
    string buildingName;
    private BuildingCreator creator;

    private void OnEnable()
    {
        CreatePub.OnClick += EventOnClick;

        
    }
    private void EventOnClick(string bName) {

        print("girdi");
        GameObject bc = GameObject.Find("BuildCreator");
        creator = (BuildingCreator)bc.GetComponent(typeof(BuildingCreator));
        buildingName = bName;
        creator.createBuilding(buildingName);


    }
    private void OnDisable()
    {
        CreatePub.OnClick -= EventOnClick; 
    }
}

