using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollButton : MonoBehaviour
{
  
    public RectTransform panel;
    public Button[] bttn;
    public RectTransform center;
   
    public float[] distance;  
    public float[] distReposition;
    private bool dragging = false; 
    private int bttnDistance;   
   private int minButtonNum;   
    private int bttnLength;
    void Start()
    {

        bttnLength = bttn.Length;
        distance = new float[bttnLength];
        distReposition = new float[bttnLength];

        // Get distance between buttons
        bttnDistance = (int)Mathf.Abs(bttn[0].GetComponent<RectTransform>().anchoredPosition.y - bttn[1].GetComponent<RectTransform>().anchoredPosition.y);
   
    }


    void Update()
    {
       
        for (int i = 0; i < bttn.Length; i++)
        {
            distReposition[i] = center.GetComponent<RectTransform>().position.y - bttn[i].GetComponent<RectTransform>().position.y;
          //  print(distReposition[0]);
            distance[i] = Mathf.Abs(distReposition[i]);
            
			if (distReposition[i] > 200)
			{
				float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
				float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

				Vector2 newAnchoredPos = new Vector2 (curX , curY + (bttnLength * bttnDistance));
				bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
			}

			if (distReposition[i] < -200)
			{
				float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
				float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

				Vector2 newAnchoredPos = new Vector2 (curX , curY - (bttnLength * bttnDistance));
				bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
			}
        }
        float minDistance = Mathf.Min(distance);
     
        for (int a = 0; a < bttn.Length; a++)
        {
            if (minDistance == distance[a])
            {
                minButtonNum = a;
            }
        }
    
        if (!dragging)
        {
         
            LerpToBttn(-bttn[minButtonNum].GetComponent<RectTransform>().anchoredPosition.y);
        }
    }
    void LerpToBttn(float position)
    {   
        float newY = Mathf.Lerp(panel.anchoredPosition.y, position, Time.deltaTime * 5f);
        Vector2 newPosition = new Vector2(panel.anchoredPosition.x,newY);
        panel.anchoredPosition = newPosition;
    }
    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }

}
