using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SellerNPC : BasicNPC, INPC
{
    [SerializeField] private List<ItemData> _sellList;

    public void Interact(object obj, Player player)
    {
        if(obj.GetType() == typeof(Shop))
        {
            obj.ConvertTo<Shop>().Open(_sellList);
        }
    }
}
