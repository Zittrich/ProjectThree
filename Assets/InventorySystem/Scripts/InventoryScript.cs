using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class InventoryScript : MonoBehaviour
{
    public InventorySlot[] InventorySlots;
    private InventorySlot _assignedSlot;
    
    public void Pickup(PickUpItem item)
    {

        
        _assignedSlot = InventorySlots.First(o => o._assignedItem == null);
        _assignedSlot.Assign(item);
        
    }
}
