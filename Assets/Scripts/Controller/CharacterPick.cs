using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPick : MonoBehaviour
{
    public bool characterSelected = false;
    RaycastHit2D ray;
    private string[] units;
    UnitOperations unitOperations;
    Vector3 parentLocation;
    ObjectCreator objectCreator;
    ButtonControl buttonControl;
    public CharacterMovement characterMovement;
   [SerializeField]
    Text text; 
    void Start()
    {
        GameObject bc = GameObject.Find("BuildCreator");
        objectCreator = (ObjectCreator)bc.GetComponent(typeof(ObjectCreator));
        unitOperations = new UnitOperations();
        GameObject bCntrl = GameObject.Find("ButtonScrollList");
        buttonControl = (ButtonControl)bCntrl.GetComponent(typeof(ButtonControl));
    }
   
    void Update()
    {
        if (Input.touchCount != 1)
        {
            return;
        }
        Touch touch = Input.touches[0];
        if (touch.phase == TouchPhase.Began)
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
            ray = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (ray.collider != null && ray.collider.tag == "building")
            {
                buttonControl.DestroyButtons();
                characterSelected = false;             
                string name = ray.transform.parent.name; 
                
                units = unitOperations.unitGetter(name);               
                parentLocation = ray.transform.parent.transform.position;
                objectCreator.buildingLocation(parentLocation);
                buttonControl.doItOnce = false;
                buttonControl.ButtonCreate(units);
                text.text = name; 
            }
            else if (ray.collider != null && ray.collider.tag == "character")
            {

                characterMovement = (CharacterMovement)ray.transform.parent.GetComponent(typeof(CharacterMovement));
                if (ray.transform.GetComponent<Renderer>().material.color == Color.blue)
                {
                    ray.transform.GetComponent<Renderer>().material.color = Color.white;
                }
                else
                    ray.transform.GetComponent<Renderer>().material.color = Color.blue;

                if (!characterSelected)
                {
                    print("girdi");
                  
                }
                characterSelected = !characterSelected;
                CreatePub.OnPickEvent(characterMovement);
            }
           

        }

    }
}
