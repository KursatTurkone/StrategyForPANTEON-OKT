using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingModel
{
    [SerializeField]
    public GameObject block;
    [SerializeField]
    public int height, weight;  
    [SerializeField]
    public string nameOfBuilding;
    [SerializeField]
    public string[] unitSize;
}
