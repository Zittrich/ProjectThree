using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchScript : InteractionScript
{
    public LightScript ConnectedLight;
    public override void Interact()
    {
        ConnectedLight.SwitchActive(!ConnectedLight._enabled);
    }
}
