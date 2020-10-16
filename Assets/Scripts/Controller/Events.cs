using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    class Events : MonoBehaviour

    {
    string buildingName;
    private BuildingCreator creator;

    private void OnEnable()
    {
        CreatePub.OnClick += EventOnClick;

        
    }
    private void EventOnClick(string bName)
    {
        buildingName = bName;
        bool dene;
        Creator creator = new Creator();
        CreatorAbstract unitless = creator.factoryMethod(buildingKindEnum.buildingKind.UnitlessCreator);
        CreatorAbstract unitCreator = creator.factoryMethod(buildingKindEnum.buildingKind.UnitCreator);
        if (!unitless.CreateBuilding(bName))
        {
            unitCreator.CreateBuilding(bName);
        }
    }
    private void OnDisable()
    {
        CreatePub.OnClick -= EventOnClick; 
    }

}

