using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootyAI : MonoBehaviour
{
    public Rigidbody2D rb; // Stores the game object's rigidbody
    private Transform player; // Stores the location of the player

    private float moveSpeed = 2f; // Stores the movement speed and sets it to 2

    private Vector2 directionToPlayer; // Stores the direction towards the player

    private float minDistance = 4f; // Stores the minimum distance the game object will keep from the player
    private float range; // Stores the distance between the player and game object

    private bool canFire = true; // Stores a bool which decides if the enemy can fire and sets it to true

    public Transform firePoint; // Stores the fire point's position
    public GameObject bullet; // Stores the bullet
    private float bulletSpeed = 6f; // Stores the bullet's speed and sets it to 6

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Sets player to the game object with the tag "Player"
    } // End of Start

    // Update is called once per frame
    void FixedUpdate()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized; // Sets the direction towards the player to the player's position with a magnitude of 1
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed; // Sets the game object's velocity to the direction to the player times the game object's move speed
        Vector2 lookDir = (player.transform.position - transform.position).normalized; // Sets the look direction to the player's position
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - -90f; // Sets the rotation to look towards from the player's position
        rb.rotation = angle; // Rotates the game object using the calculated angle
        StartCoroutine(Shooting()); // Start the Shooting coroutine

        range = Vector2.Distance(transform.position, player.position); // Gets the range of the player to the game object
        if (range < minDistance) // Checks if the range to the player is less than the minimum distance
        { // If the range to the player is less than the minimum distance,
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * -0.04f); // Change the move speed and positioning of the game object to a standstill
        }
    } // End of FixedUpdate

    // Called by Start
    IEnumerator Shooting()
    {
        if (canFire == true)
        { // If canFire is true,
            canFire = false; // Set can fire to false
            GameObject EnemyShot = Instantiate(bullet, firePoint.position, firePoint.rotation); // Sets the bullet to the position and rotation of the firepoint
            Rigidbody2D rigidb = EnemyShot.GetComponent<Rigidbody2D>(); // Gets the rigidbody of the bullet
            rigidb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);  // Takes the rigidbody of the bullet and applies force to it, coming out upwards from the fire point
            yield return new WaitForSecondsRealtime(2f); // Wait for 2 seconds
            canFire = true; // Set can fire to true
        }
    } // End of Shooting
} // End of class
