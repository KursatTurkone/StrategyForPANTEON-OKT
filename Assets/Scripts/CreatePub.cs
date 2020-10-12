
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


  public class CreatePub 
{

    public static event System.Action<string> OnClick; 

    public static void OnClickFunction(string nameOfBuilding)
    {
        OnClick?.Invoke(nameOfBuilding); 
        
    }
  



   
    
}
