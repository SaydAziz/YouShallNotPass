using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Inventory))]
public class Player : MonoBehaviour
{
    private Inventory playerInv;
    void Awake()
    {
        playerInv = GetComponent<Inventory>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
