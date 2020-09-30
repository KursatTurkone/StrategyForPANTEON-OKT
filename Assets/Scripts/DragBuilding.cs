using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBuilding : MonoBehaviour
{
    private bool dragging = false;
    public bool dropped = false;
    private Vector3 offset;
    private Transform toDrag;
    private float dist;
    RaycastHit2D ray;
    Vector3 truePos;


    void Update()
    {
       if(!dropped)
        {
            if (Input.touchCount != 1)
            {
                dragging = false;
                
                return;
            }
            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                dropped = false;

                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
                ray = Physics2D.Raycast(worldPoint, Vector2.zero);
                if (ray.collider != null && ray.collider.tag == "block")
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
                dropped = true;
                dragging = false;
              //  this.gameObject.GetComponent<DragBuilding>().enabled = false;

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

