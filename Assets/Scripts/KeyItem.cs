using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : Item
{
    protected override void Pickup()
    {
        CaveEntranceController caveController = FindObjectOfType<CaveEntranceController>();

        base.Pickup();
        caveController.OpenCaveEntrance();
    }

    public override void Use()
    {
        
    }
}
