using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    
    
    void Awake()
    {
        _itemName = "Sword";

    }


    protected override void Start()
    {
        base.Start();
    }

    public override void Use()
    {
        
    }


}
