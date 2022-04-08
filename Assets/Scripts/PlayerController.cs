using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float moveDir;
    private float moveDirCache;

    private float moveSpeed = 20;
    private float jumpForce = 25;
    private float normGrav = 10;
    private float fallGrav = 15;
    private float crouchTime = 0.5f;

    private bool moveBlocked = false;
    private bool crouching = false;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!moveBlocked)
        {
            rb.velocity = new Vector2((moveDir * moveSpeed), rb.velocity.y);
            moveDirCache = rb.velocity.x;
        }
        else if (crouching)
        {
            rb.velocity = new Vector2((moveDirCache), rb.velocity.y);

        }

        if (rb.velocity.y < 1)
        {
            rb.gravityScale = fallGrav;
        }
        else
        {
            rb.gravityScale = normGrav;
        }
    }

    public void DoMovement(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<float>();
    }

    public void DoJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void DoCrouch(InputAction.CallbackContext context)
    {
        if (context.started && !crouching)
        {
            float xDirCache = moveDir;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
            moveBlocked = true;
            crouching = true;
            StartCoroutine(CrouchReset());
        }
    }


    private IEnumerator CrouchReset()
    {
        yield return new WaitForSeconds(crouchTime);
        moveBlocked = false;
        crouching = false;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
    }
}
