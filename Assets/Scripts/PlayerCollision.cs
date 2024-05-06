using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other) {
     Debug.Log("Tag: " + other.transform.tag);
    if(other.transform.tag == "Obstaculo") {
        Destroy(gameObject);
        GameManager.Instance.GameOver();
    }
   }
}
