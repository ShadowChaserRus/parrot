using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTest : MonoBehaviour
{
    public static Character _char = new Character("ShadowChaser", 1);
    public int Level;
    private void Awake()
    {
        _char.Setlvl(Level);
        // Clan.CreateClan("ShadowChaserClan", _char);

    }
}
