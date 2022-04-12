using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Inventory))]
public class Player : MonoBehaviour
{
    private Inventory playerInv;

    private float health = 100;
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

    public void Use()
    {
        playerInv.itemInventory[0].Use();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.Spawn(this.gameObject);
        Destroy(this.gameObject);
    }
}
