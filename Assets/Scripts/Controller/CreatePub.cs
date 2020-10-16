
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


  public class CreatePub 
{
    public static event System.Action<string> OnClick;
    public static event System.Action<CharacterMovement> PickEvent;
    public static void OnClickFunction(string nameOfBuilding)
    {
        OnClick?.Invoke(nameOfBuilding);
    }
    public static void OnPickEvent(CharacterMovement characterMovement)
    {
        PickEvent?.Invoke(characterMovement);
    }
}
