using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : InteractionScript
{
    private InventoryScript inventory;

    public Sprite InventoryIcon;
    public GameObject ThisItem;
    public string Name;
    public string InfoText;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("InventoryScreen").GetComponent<InventoryScript>();
    }
    public override void Interact()
    {
        inventory.Pickup(this);
    }
}
