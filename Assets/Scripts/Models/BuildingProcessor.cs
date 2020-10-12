using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine; 


    class BuildingProcessor
    {
            GameObject block;
            string name;
            int height, weight;
            bool createUnits;
            string nameOfBuilding;               
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
    

