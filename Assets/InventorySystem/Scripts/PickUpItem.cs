using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : InteractionScript
{
    private InventoryScript _inventory;

    public Sprite InventoryIcon;
    public GameObject ThisItem;
    public string Name;
    public string InfoText;

    public void Start()
    {
        _inventory = Manager.Use<UIManager>().Inventory;
    }
    public override void Interact()
    {
        _inventory.Pickup(this);
        base.Interact();
    }
}
