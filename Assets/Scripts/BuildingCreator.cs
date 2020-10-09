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
    GameObject blockField;
    [SerializeField]
    GameObject target; 
    [SerializeField]
    List<BuildingModel> buildingCreates = new List<BuildingModel>();
    List<BuildingProcessor> buildings = new List<BuildingProcessor>();
    List<UnitProcessor> units = new List<UnitProcessor>();
    private string[] fill;
    private int Weight, Height;


    void Start()
    {
       
        for(int i = 0; i < buildingCreates.Count; i++)
        {
           
           
            if (buildingCreates[i].unitSize.Length == 0)
            {
                BuildingProcessor building = new BuildingProcessor();
                building.setBlock(buildingCreates[i].block);
                building.setHeight(buildingCreates[i].height);
                building.setName(buildingCreates[i].nameOfBuilding);
                building.setWeight(buildingCreates[i].weight);
                buildings.Add(building);
            }
            else
            {
                UnitProcessor unit = new UnitProcessor();
                unit.setBlock(buildingCreates[i].block);
                unit.setHeight(buildingCreates[i].height);
                unit.setName(buildingCreates[i].nameOfBuilding);
                unit.setWeight(buildingCreates[i].weight);
                unit.setUnitSize(buildingCreates[i].unitSize);
             
                units.Add(unit);
            }
          
          //  Building building = new Building();

       
           
           
        }
       

     
    }   
 
    public void createBuilding(string buttonName)
    {

     GameObject parent=   Instantiate(blockField, new Vector2(-50, 200), Quaternion.identity);
      
      
        foreach(BuildingProcessor building in buildings)
           
        {if (building.getName() == buttonName)
            {for(int i=0;i< building.getHeight(); i++)
                {
                    for(int j = 0; j < building.getWeight(); j++)
                    {
                        GameObject myNewBuilding = Instantiate(building.getBlock(), new Vector2(-50+(i*32), 200+(j*32)), Quaternion.identity);
                        myNewBuilding.transform.parent = parent.transform;
                        parent.name = building.getName(); 
                    }
                }
            }
            else
            {
                foreach(UnitProcessor units in units)
                {
                    if (units.getName() == buttonName)
                    {
                        for (int i = 0; i < units.getHeight(); i++)
                        {
                            for (int j = 0; j < units.getWeight(); j++)
                            {
                                GameObject myNewBuilding = Instantiate(building.getBlock(), new Vector2(-50 + (i * 32), 200 + (j * 32)), Quaternion.identity);
                                myNewBuilding.transform.parent = parent.transform;
                                parent.name = units.getName();
                            }
                        }
                    }
                }
            }

        }
      
        
    }
    public void deneme()
    {
        print("dene");
    }
    public (int, int) unitSet(string unitName)
    {


        foreach (UnitProcessor unit in units)
        {
            string[] getUnits = unit.getUnitSize();
            
           
                if (getUnits.Contains(unitName))
                {
                    Height = unit.getHeight();
                    Weight = unit.getWeight();
                }
                else
                {                   
                    Height = 0;
                    Weight = 0;
                }
               
            }

        return (Height, Weight);



    }
    
    public string[] unitGetter(string buildingName)
    {


        foreach (UnitProcessor unit in units)
        {
            if (unit.getName() == buildingName)
            {

                fill = unit.getUnitSize();
              

            }
            else
            {
                print("null geldi");
                fill = null;
            }
        }
        return (fill);


    }


    /* public class UnitCreator : BuildingProcessor
     {
        /* string[] unitName;

         public string[] getUnitName()
         {
             return unitName;
         }
         public void setUnitSize(string[] unitName)
         {
             this.unitName = unitName;
         }


         public void UnitWindow()
         {

             if (unitName == 0)
             {
                 //liste yerinde yazı göster
             }
             else {
                 for (int i = 0; i < unitName.Length; i++)
                 {
                     //create UnitWindow buttons and list it 
                 }
             }


         }

     }*/
}
   


