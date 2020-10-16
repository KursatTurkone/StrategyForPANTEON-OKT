using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    class PickEvents:MonoBehaviour
    {
        [SerializeField]
        GameObject button;
       
        private void OnEnable()
        {
            CreatePub.PickEvent += EventOnClick;
        }

      
        private void EventOnClick(CharacterMovement characterMovement)
        {
            
            characterMovement.enabled = !characterMovement.enabled;
            
        }
        private void OnDisable()
        {
            CreatePub.PickEvent -= EventOnClick;
        }
    }
}
