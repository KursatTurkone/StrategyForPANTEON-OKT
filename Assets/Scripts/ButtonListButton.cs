using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{
    BuildingCreator buildingCreator;
    [SerializeField]
    ObjectCreator objectCreator; 
    [SerializeField]
    private Text barrackText;
    string nameOfUnit,nameOfButton;
    private int weight, height;
  
    private void Start()
    {
        GameObject bc = GameObject.Find("BuildCreator");
        buildingCreator = (BuildingCreator)bc.GetComponent(typeof(BuildingCreator));
    }

    public void SetText(string textString)
    {
        barrackText.text = textString;
        gameObject.name = textString;

    }

    public void OnClick()
    {
        nameOfButton = EventSystem.current.currentSelectedGameObject.name;

       
        (height, weight) = buildingCreator.unitSet(nameOfButton);
        if (height > 0 && weight > 0)
            objectCreator.lengthGetter(height, weight);
        else
            print("olmadı");

    }
}
