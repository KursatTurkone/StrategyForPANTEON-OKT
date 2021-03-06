﻿using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragBuilding : MonoBehaviour
{
    ClickButtons ClickButtons;
    private bool dragging = false;
    public bool dropped = false;
    private Vector3 offset;
    private Transform toDrag;
    private float dist;
    RaycastHit2D ray;
    Vector3 truePos;
    private void Start()
    {  
        GameObject dc = GameObject.Find("Controller");
        ClickButtons = (ClickButtons)dc.GetComponent(typeof(ClickButtons));
    }
    void Update()
    {
        if (Input.touchCount != 1)
        {
            dragging = false;

            return;
        }
        Touch touch = Input.touches[0];

        if (!dropped)
        {
            if (touch.phase == TouchPhase.Began)
            {



                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
                ray = Physics2D.Raycast(worldPoint, Vector2.zero);
                if (!dropped && ray.collider != null && ray.collider.tag == "block")
                {
                    ray.transform.parent.position = new Vector3(ray.transform.parent.position.x, ray.transform.parent.position.y, 0);
                    toDrag = ray.transform.parent.transform;
                    dist = Camera.main.WorldToScreenPoint(ray.transform.parent.position).z;
                    offset = ray.transform.parent.position - GetTouchWorldPos();
                    dragging = true;
                }


            }
            if (dragging && touch.phase == TouchPhase.Moved)
            {
                truePos.x = Mathf.Floor(GetTouchWorldPos().x / 32) * (32) + (32 / 2);
                truePos.y = Mathf.Floor(GetTouchWorldPos().y / 32) * (32) + (32 / 2);
                toDrag.position = truePos;
            }
            if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
            {
                ClickButtons.changeState();
                dropped = true;
                dragging = false;
            }
        }   
    }
    private Vector3 GetTouchWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = dist;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


     
}

