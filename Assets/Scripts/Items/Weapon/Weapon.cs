using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    
    void Start()
    {
        
    }

    public override void Use()
    {
        Debug.Log(itemName + "was used.");
    }
}
