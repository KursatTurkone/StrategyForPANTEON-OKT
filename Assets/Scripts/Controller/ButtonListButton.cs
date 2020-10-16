using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{ 
    [SerializeField]
    ObjectCreator objectCreator; 
    [SerializeField]
    private Text barrackText;
    string nameOfUnit,nameOfButton;
    private int weight, height;
    UnitOperations unitOperations;
    public void SetText(string textString)
    {
         unitOperations = new UnitOperations();
        barrackText.text = textString;
        gameObject.name = textString;

    }
    public void OnClick()
    {
        nameOfButton = EventSystem.current.currentSelectedGameObject.name;   
            (height, weight) = unitOperations.unitSet(nameOfButton);
        if (height > 0 && weight > 0)
            objectCreator.lengthGetter(height, weight);
       

    }
}
