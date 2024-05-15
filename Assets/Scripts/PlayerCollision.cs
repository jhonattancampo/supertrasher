using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.onPlay.AddListener(ActivatePlayer);
        GameManager.Instance.onGameOver.AddListener(DeactivatePlayer);
    }

    private void ActivatePlayer()
    {
        gameObject.SetActive(true);
    }

    private void DeactivatePlayer()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstaculo")
        {
            // Use the AdjustScore method to decrement the score
            GameManager.Instance.AdjustScore(-1);
        }
        else if (other.transform.tag == "Trash")
        {
            // Use the AdjustScore method to increment the score
            GameManager.Instance.AdjustScore(1);
        }
    }
}
