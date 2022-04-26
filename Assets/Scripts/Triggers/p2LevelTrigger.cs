using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2LevelTrigger : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player2")
        {
            GameManager.Instance.SetLevel(-1);
        }

    }
}
