using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Scripts
{    
    class ButtonControl :MonoBehaviour
    {
        [SerializeField]
        private GameObject buttonTamplate;
        private HashSet<string> set = new HashSet<string>();
        bool doItOnce =false; 


        public void ButtonCreate(string[] units)
        {

            if (units != null)
            {
                if (!doItOnce) {
                    for (int i = 0; i < units.Length; i++)
                    {
                        GameObject button = Instantiate(buttonTamplate) as GameObject;
                        button.SetActive(true);
                        button.GetComponent<ButtonListButton>().SetText(units[i]);
                        button.transform.SetParent(buttonTamplate.transform.parent, false);
                        doItOnce = true;
                    }
                }
               
            }
            else
            {
                print("boş");
            }

            }
        }


    }

