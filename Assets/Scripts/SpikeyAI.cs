using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeyAI : MonoBehaviour
{
    public Rigidbody2D rb; // Stores the game object's rigidbody
    private Transform player; // Stores the location of the player

    private float moveSpeed = 4f; // Stores the movement speed and sets it to 4

    private Vector2 directionToPlayer; // Stores the direction towards the player

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Sets player to the game object with the tag "Player"
    } // End of Start

    // FixedUpdate is called once per physics frame
    private void FixedUpdate()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized; // Sets the direction towards the player to the player's position with a magnitude of 1
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed; // Sets the game object's velocity to the direction to the player times the game object's move speed
        Vector2 lookDir = (player.transform.position - transform.position).normalized; // Sets the look direction to the player's position
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - -90f; // Sets the rotation to look towards from the player's position
        rb.rotation = angle; // Rotates the game object using the calculated angle
    } // End of FixedUpdate
} // End of class 


