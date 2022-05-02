using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public PickUpItem _assignedItem;

    public Image Image;

    private GameObject _player;
    private Collider _collider;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Assign(PickUpItem item)
    {
        _assignedItem = item;
        Image.sprite = item.InventoryIcon;
        item.gameObject.SetActive(false);
        _collider = item.GetComponent<Collider>();
    }

    public void Unassign()
    {
        _assignedItem.gameObject.SetActive(true);
        _assignedItem.transform.position = _player.transform.position + _player.transform.forward * new Vector3(0, 0, _player.GetComponent<Collider>().bounds.extents.z + _collider.bounds.extents.z);
        Image.sprite = null;
        _assignedItem = null;
    }

    public void Interact()
    {
        Unassign();
    }
}
