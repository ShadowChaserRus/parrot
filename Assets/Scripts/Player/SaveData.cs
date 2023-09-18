using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewPlayerSave", menuName = "Player/Save Data", order = 1)]
public class SaveData : ScriptableObject
{
    public Vector2 SavePoint;
}
