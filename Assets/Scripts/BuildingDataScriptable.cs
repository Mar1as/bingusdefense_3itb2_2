using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "DataAssets/BuildingData", order = 0)]
public class BuildingDataScriptable : ScriptableObject
{
    public List<BuildingData> Buildings; 
}

[Serializable]
public class BuildingData
{
    

    public BuildingType BuildingType;
    public GameObject Prefab;
    public string Name;
    public string Description;
    public int Cost;

}

public enum BuildingType { 
    Tower, Ammo
}