using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class UnitProcessor :BuildingProcessor
    {
         string[] unitSize;
   
        public string[] getUnitSize()
        {
            return unitSize;
        }
        public void setUnitSize(string[] unitSize)
        {
            this.unitSize = unitSize;
        }
      
    }
}
