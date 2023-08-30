using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClanTest : MonoBehaviour
{
    public static List<Clan> ClanList = new(10);
    private void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            Clan newClan = Clan.CreateClan($"a + {i}", false, new Character($"Name + {i}", i));
            newClan.SetRequirement(i);
            ClanList.Add(newClan);
        }
    }
}
