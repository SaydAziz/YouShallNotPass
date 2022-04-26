using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Inventory))]
public class Player : MonoBehaviour
{
    private Inventory playerInv;
    private Collider2D collider;
    private RaycastHit2D hit;
    private Transform respawnLoc;

    private float health = 100;
    private float cachedDir = -1;
    void Awake()
    {
        playerInv = GetComponent<Inventory>();
        collider = GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    void FixedUpdate()
    {
        hit = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, 1, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawRay(collider.bounds.center - new Vector3(collider.bounds.extents.x, collider.bounds.extents.y + 0.1f, 0), Vector2.right * (collider.bounds.extents.x * 2), Color.red);
    }

    public bool GroundCheck()
    {
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void Use()
    {
        playerInv.itemInventory[0].Use();
    }

    public void CheckDir(float moveDir)
    {
        if (moveDir == 0) return; //Guard clause 
        if (moveDir != cachedDir)
        {
            gameObject.transform.localScale = gameObject.transform.localScale * -1;
            cachedDir = moveDir;
        }

    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            health = 0;
            Die();
            Respawn();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public void SetRespawnLoc(Transform location)
    {
        respawnLoc = location;
    }

    public void Respawn()
    {
        health = 100;
        playerInv.ClearInv();
        gameObject.transform.position = respawnLoc.position;
        gameObject.SetActive(true);
    }
}
