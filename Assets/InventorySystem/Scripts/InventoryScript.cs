using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public InventorySlot[] InventorySlots;
    
    public void Pickup(PickUpItem item)
    {
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            if(InventorySlots[i]._assignedItem == null)
            {
                InventorySlots[i].Assign(item);
                break;
            }
        }
    }
}
