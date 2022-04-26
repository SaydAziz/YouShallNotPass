using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Player2")
        {
            if (other.gameObject.tag == "Player")
            {
                GameManager.Instance.AddScore(1);
            }
            else if (other.gameObject.tag == "Player2")
            {
                GameManager.Instance.AddScore(2);
            }
            StartCoroutine(GameManager.Instance.ResetGame());
        }

    }
}
