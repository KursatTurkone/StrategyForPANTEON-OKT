using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class UnitOperations
    {
        BuildingCreator buildingCreator;
        private int Weight, Height;
        private string[] fill;
      public  UnitOperations()
        {
            GameObject bc = GameObject.Find("BuildCreator");
            buildingCreator = (BuildingCreator)bc.GetComponent(typeof(BuildingCreator));
        }
        public (int, int) unitSet(string unitName)
        {
            foreach (UnitProcessor unit in buildingCreator.units)
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


            foreach (UnitProcessor unit in buildingCreator.units)
            {
                
                if (unit.getName() == buildingName)
                {                
                    fill = unit.getUnitSize();
                    break;
                }
                else
                {     
                    fill = null;
                }
            }
            return (fill);


        }
    }
}
