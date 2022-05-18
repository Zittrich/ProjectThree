using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InventorySlot : MonoBehaviour
{
    public PickUpItem _assignedItem { get; private set; }

    public Image Image;
    public TextMeshProUGUI Name;

    private GameObject _player;
    private Collider _collider;

    private void Start()
    {
        _player = Manager.Use<PlayerManager>().Player;
    }
    public void Assign(PickUpItem item)
    {
        item.gameObject.SetActive(false);

        _collider = item.GetComponent<Collider>();
        Image.sprite = item.InventoryIcon;
        Name.text = item.Name;
        _assignedItem = item;
    }

    public void Unassign()
    {
        _assignedItem.gameObject.SetActive(true);

        _assignedItem.transform.position = _player.transform.position 
            + (_player.transform.forward * (_player.GetComponent<Collider>().bounds.extents.z + _collider.bounds.extents.z)) 
            + _player.transform.up * _player.GetComponent<Collider>().bounds.extents.y;

        Image.sprite = null;
        _assignedItem = null;
        Name.text = "";
    }

    public void Interact()
    {
        Unassign();
    }
}
