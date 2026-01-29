using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplicitButton : BaseButton
{
    public override void Interact()
    {
        base.Interact();
        _canInteract = false;
    }
}
