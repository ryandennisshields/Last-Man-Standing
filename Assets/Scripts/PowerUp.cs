using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static PowerUp instance; // Creates an instance of this script, allowing other scripts to use it
    public SpriteRenderer spriteRenderer; // Stores the sprite renderer of a game object
    public Sprite powerupSprite; // Stores the powered-up sprite
    public Sprite normalSprite; // Stores the normal (default) sprite
    public GameObject pickupEffect; // Stores the pick up 

    // Called when the script starts
    void Awake()
    {
        instance = this; // Sets the instance of a script to this script
    } // End of awake

    // Called whenever this collider hits a trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") // Checks if the other trigger has the tag "Player"
        { // If the other trigger does have the tag "Player",
            spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>(); // Grabs the sprite renderer of the object that collided and triggered
            PickUp(other); // Runs the pick up script effecting the other object
        }
    } // End of on trigger enter
    
    // Called by trigger enter 
    void PickUp(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation); // Creates the pick up effect on the power-up game object
        spriteRenderer.sprite = powerupSprite; // Changes the player's sprite to the powered-up sprite
        HealthManager.instance.currentHealth += 1; // Adds an extra point of health (the power up's effect)
        GameManager.instance.powerupHP = HealthManager.instance.currentHealth; // Sets the GameManger's power up HP to the HealthManager's current health
        Destroy(gameObject); // Removes the power-up
    } // End of PickUp
} // End of class
