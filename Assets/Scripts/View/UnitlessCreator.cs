using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class UnitlessCreator : CreatorAbstract
    {
        BuildingCreator buildingCreator;
        public override bool CreateBuilding(string buttonName)
        {
            GameObject bc = GameObject.Find("BuildCreator");
            buildingCreator = (BuildingCreator)bc.GetComponent(typeof(BuildingCreator));
            GameObject parent = Instantiate(buildingCreator.blockField, new Vector2(-50, 200), Quaternion.identity);
            bool find=false;
            foreach (BuildingProcessor building in buildingCreator.buildings)

            {
                if (building.getName() == buttonName)
                {
                    for (int i = 0; i < building.getHeight(); i++)
                    {
                        for (int j = 0; j < building.getWeight(); j++)
                        {
                            GameObject myNewBuilding = Instantiate(building.getBlock(), new Vector2(-50 + (i * 32), 200 + (j * 32)), Quaternion.identity);
                            myNewBuilding.transform.parent = parent.transform;
                            parent.name = building.getName();
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
