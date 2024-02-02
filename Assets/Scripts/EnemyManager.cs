using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyImpact; // Stores the enemy impact particle effect
    
    // Called whenever the object collides with anything
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player") // Check if the owner of the other collision has the tag "Player"
        { // If the other collision has the tag "Player",
            HealthManager.instance.DamagePlayer(); // Calls the DamagePlayer script from HealthManager
            Instantiate(enemyImpact, transform.position, transform.rotation); // Creates the enemy impact particle effect on the owner of the code
            Destroy(this.gameObject); // Destroys the game object of the code owner
        }

    } // End of on collision enter

    // Called when the game object gets destroyed
    private void OnDestroy()
    {
        EnemyGeneration.instance.enemyCount -= 1; // Takes one away from EnemyGeneration's enemy count
    } // End of on destroy

} // End of class
