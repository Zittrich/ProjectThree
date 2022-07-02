using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DoorScript : InteractionScript
{
    private bool _isOpen;

    public override void Interact()
    {
        if(!_isOpen)
        {
            transform.DORotate(new Vector3(0, -90), 1);
            _isOpen = true;
        }
        else
        {
            transform.DORotate(new Vector3(0, 0), 1);
            _isOpen = false;
        }
        base.Interact();
    }
}
