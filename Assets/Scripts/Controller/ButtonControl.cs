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
       public bool doItOnce =false;
        bool tryonce = false;
        GameObject blc;
        private void Start()
        {
            blc = GameObject.Find("ButtonListContent");
        }
        public void ButtonCreate(string[] units)
        {

            if (units != null)
            {
                if (!doItOnce) {
                  
                    for (int i = 0; i < units.Length; i++)
                    {
                      // if(blc.transform.GetChild(i).gameObject.name==units[i])
                        GameObject button = Instantiate(buttonTamplate) as GameObject;
                        button.SetActive(true);
                        button.GetComponent<ButtonListButton>().SetText(units[i]);
                        button.transform.SetParent(buttonTamplate.transform.parent, false);
                        doItOnce = true;
                    
                    }
                }
               
            }
            }
        public void DestroyButtons()
        {
            int count = 1;
           
                while(count<blc.transform.childCount)
                {
                    GameObject.Destroy(blc.transform.GetChild(count).gameObject);
                    tryonce = true;
                    count++;
                }
        }
        }


    }

