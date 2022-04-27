using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorScript : InteractionScript
{
    private bool _isOpen;
    public override void Interact()
    {
        if(!_isOpen)
        {
            transform.Rotate(new Vector3(0, -90));
            _isOpen = true;
        }
        else
        {
            transform.Rotate(new Vector3(0, 90));
            _isOpen = false;
        }
    }
}
