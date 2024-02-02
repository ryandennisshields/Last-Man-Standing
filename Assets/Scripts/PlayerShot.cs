using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject hitEffect; // Stores the hit particle effect

    public GameObject enemyImpact; // Stores the enemy impact particle effect

    // Called when this collider touches another collider
    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity); // Create a hit effect on the shot
        Destroy(gameObject); // Destroy this game object 
        if (other.gameObject.tag != "Obstacle" && other.gameObject.tag != "Player") // Checks if the other game object does not have the tag "Obstacle" and "Player"
        { // If the other game object does not have either tag,
            GameObject impact = Instantiate(enemyImpact, other.transform.position, other.transform.rotation); // Creates the enemy impact particle effect on the other object
            Destroy(impact, 1f); // Destroys the enemy impact particle effect after 1 second
            Destroy(other.gameObject); // Destroys the other game object
            if (other.gameObject.tag == "Spikey") // Checks if the other game object has the tag "Spikey"
            { // If the other game object does have the tag "Spikey",
                GameManager.instance.AddScore(1000); // Add 100 score to the GameManager AddScore function
            }
            if (other.gameObject.tag == "Shooty") // Checks if the other game object has the tag "Shooty"
            { // If the other game object does have the tag "Shooty",
                GameManager.instance.AddScore(1000); // Add 200 score to the GameManager AddScore function
            }
        }
    } // End of on collision enter
} // End of class
