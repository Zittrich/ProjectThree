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

    private void Start()
    {
        _inventory = Manager.Use<UIManager>().Inventory;
        ThisItem = gameObject;
    }
    public override void Interact()
    {
        _inventory.Pickup(this);
    }
}
