using Assets.Scripts;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BuildingCreator : MonoBehaviour
{
    [SerializeField]
   public GameObject blockField;

    [SerializeField]
    List<BuildingModel> buildingCreates = new List<BuildingModel>(); 
    public  ArrayList buildings = new ArrayList();
    public ArrayList units = new ArrayList(); 

  
    void Start()
    {     
        for (int i = 0; i < buildingCreates.Count; i++)
        {
            if (buildingCreates[i].unitSize.Length == 0)
            {
              
               //set building features
                BuildingProcessor building = new BuildingProcessor();
                building.setBlock(buildingCreates[i].block);
                building.setHeight(buildingCreates[i].height);
                building.setName(buildingCreates[i].nameOfBuilding);
                building.setWeight(buildingCreates[i].weight);
                buildings.Add(building);
            }
            else
            {
               
                //set Unitbuilding features
                UnitProcessor unit = new UnitProcessor();
                unit.setBlock(buildingCreates[i].block);
                unit.setHeight(buildingCreates[i].height);
                unit.setName(buildingCreates[i].nameOfBuilding);
                unit.setWeight(buildingCreates[i].weight);
                unit.setUnitSize(buildingCreates[i].unitSize);
                units.Add(unit);
            }
        }
    }
  
  
   


  
}
   


