using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    
    private Animator anim;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        _itemName = "Sword";
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void Use()
    {
        Debug.Log("Attacking...");
    }


}
