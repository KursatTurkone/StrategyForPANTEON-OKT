using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class Creator
    {      
            public CreatorAbstract factoryMethod(buildingKindEnum.buildingKind kind)
            {
                CreatorAbstract creator = null;
                switch (kind)
                {
                case buildingKindEnum.buildingKind.UnitlessCreator:
                        creator = new UnitlessCreator();
                        break;
                case buildingKindEnum.buildingKind.UnitCreator:
                        creator = new UnitCreator();
                        break;
                }
                return creator;
            }               
    }

}
