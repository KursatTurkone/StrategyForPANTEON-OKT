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
        private Text barrackText;
      

        private string myTextString; 
        public void SetText(string textString)
        {
           
            myTextString = textString;
            
            barrackText.text = textString;
        }
       
        public void OnClick()
        {
           
           
        }
    }
}
