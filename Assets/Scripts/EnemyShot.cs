using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject hitEffect; // Stores the hit particle effect

    // Called whenever the a collision happens
    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity); // Create the hit particle effect where the bullet lands
        Destroy(gameObject); // Destroys the owner's gameobject
        if (other.gameObject.tag == "Player") // Sets other to a gameobject with the tag Player
        { // If other is a game object with the tag "Player",
            HealthManager.instance.DamagePlayer(); // Damages the player using healthmanager
        }
    } // End of on collison enter
} // End of class

