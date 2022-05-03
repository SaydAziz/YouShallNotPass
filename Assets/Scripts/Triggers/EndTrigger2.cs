using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger2 : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player2")
        {
            GameManager.Instance.AddScore(2); 
            StartCoroutine(GameManager.Instance.ResetGame());
        }

    }
}
