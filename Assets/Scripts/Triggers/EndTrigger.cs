using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.AddScore(1);
            StartCoroutine(GameManager.Instance.ResetGame());
        }

    }
}
