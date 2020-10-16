using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class UnitCreator : CreatorAbstract
    {
        BuildingCreator buildingCreator;
        public override bool CreateBuilding(string buttonName)
        {
            GameObject bc = GameObject.Find("BuildCreator");
            buildingCreator = (BuildingCreator)bc.GetComponent(typeof(BuildingCreator));
            GameObject parent = Instantiate(buildingCreator.blockField, new Vector2(-50, 200), Quaternion.identity);
            bool find =false;
            foreach (UnitProcessor units in buildingCreator.units)
            {
                if (units.getName() == buttonName)
                {
                    for (int i = 0; i < units.getHeight(); i++)
                    {
                        for (int j = 0; j < units.getWeight(); j++)
                        {
                            GameObject myNewBuilding = Instantiate(units.getBlock(), new Vector2(-50 + (i * 32), 200 + (j * 32)), Quaternion.identity);
                            myNewBuilding.transform.parent = parent.transform;
                            parent.name = units.getName();
                        }
                    }
                    find = true;
                }
                else
                    find = false; 
            }
            return find;
        }
    }
}
