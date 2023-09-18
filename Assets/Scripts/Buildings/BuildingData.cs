using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuilding", menuName = "Buildings/Building Data", order = 1)]
public class BuildingData : ScriptableObject
{
    public Sprite GroundSprite;
    public int ID;
    public string Name;
    public BuildingType BuildingType = BuildingType.One;
    public List<ResourceType> BuildResources;
    public List<int> RecourceAmount;
    public int TimeHour;
    public int TimeMinute;
    public int TimeSecond;
    public int Price;
    public BuildingWindow _buildingWindow;
}

public enum BuildingType
{
    One,
    Two,
    Three
}
