using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    protected Animator anim; 
    public override void Use()
    {
        Debug.Log(itemName + "was used.");
    }

    protected override void Start()
    {
        anim = GetComponent<Animator>();
        if (isPickedUp)
        {
            anim.enabled = true;
        }
        base.Start();
    }
}
