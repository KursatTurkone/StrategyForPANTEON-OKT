using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingCreator : MonoBehaviour
{
    [SerializeField]
    GameObject blockField;
    [SerializeField]
    GameObject target; 
    [SerializeField]
    List<BuildingCreate> buildingCreates = new List<BuildingCreate>();
   

    List<Building> buildings = new List<Building>();
    [System.Serializable]
    public class BuildingCreate
    {
        [SerializeField]
        public GameObject block;
        [SerializeField]
        public int height, weight;
        [SerializeField]
        public int numberOfUnits; 
        [SerializeField]
        public string nameOfBuilding;
        [SerializeField]
        public string[] unitSize; 
    }    
    void Start()
    {
       
        for(int i = 0; i < buildingCreates.Count; i++)
        {
            Building building = new Building();
          //  Building building = new Building();

            building.setBlock(buildingCreates[i].block) ;
            building.setHeight(buildingCreates[i].height);
            building.setName(buildingCreates[i].nameOfBuilding);
            building.setWeight(buildingCreates[i].weight);
            building.setUnitSize(buildingCreates[i].unitSize);
            buildings.Add(building); 
        }
       

     
    }   
    public class Building
    {

        GameObject block;
        string name;
        int height, weight;
        bool createUnits;
        string nameOfBuilding;
        string[] unitSize;


        public string[] getUnitSize()
        {
            return unitSize;
        }
        public void setUnitSize(string[] unitSize)
        {
            this.unitSize = unitSize;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public int getHeight()
        {
            return height;
        }
        public void setHeight(int height)
        {
            this.height = height;
        }

        public int getWeight()
        {
            return weight;
        }
        public void setWeight(int weight)
        {
            this.weight = weight;
        }

        public GameObject getBlock()
        {
            return block;
        }
        public void setBlock(GameObject block)
        {
            this.block = block;
        }






    }
    public void createBuilding(string buttonName)
    {
        print(buttonName);
     GameObject parent=   Instantiate(blockField, new Vector2(-50, 200), Quaternion.identity);
      
      
        foreach(Building building in buildings)
        {if (building.getName() == buttonName)
            {for(int i=0;i< building.getHeight(); i++)
                {
                    for(int j = 0; j < building.getWeight(); j++)
                    {
                        GameObject myNewBuilding = Instantiate(building.getBlock(), new Vector2(-50+(i*32), 200+(j*32)), Quaternion.identity );
                        myNewBuilding.transform.parent = parent.transform; 
                    }

                }
              
              
                //get ile al ve Instantiate et 
            }

        }
      
        
    }
    public void deneme()
    {
        print("dene");
    }

    public class UnitCreator : Building
    {
        string[] unitName;
    
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
            if (unitName == null)
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

    }
}
   


