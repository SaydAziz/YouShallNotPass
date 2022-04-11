using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    
    public override void Use()
    {
        Debug.Log(itemName + "was used.");
    }

    protected override void Start()
    {
        base.Start();
    }
}
