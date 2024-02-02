using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public static HealthManager instance; // Allows other scripts to use code from healthmanager

    public int currentHealth; // Stores the current health
    public int maxHealth; // Stores the maximum health
    public int powerupHP; // Stores the HP of the power up
    public SpriteRenderer spriteRenderer; // Store a sprite renderer

    public Sprite normalSprite; // Stores the player's regular sprite

    public GameObject playerDeathEffect; // Stores the player's death effect

    public AudioSource hurtSound; // Stores the player hurt sound

    // Awake is called when the game starts
    void Awake()
    {
        instance = this; // Allows other scripts to use code from healthmanager


    } // End of Awake

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // Sets the current health to be the maximum health
        UIManager.instance.healthBar.maxValue = maxHealth; // Sets the health bar's maximum health value from UI manager to the max health value
        UIManager.instance.healthBar.value = currentHealth; // Sets the health bar's value from UI manager to the current health value

    } // End of start

    // Damageplayer is called when the player takes damage from a source
    public void DamagePlayer()
    {
        currentHealth--; // Reduces the player's health
        hurtSound.Play();
        UIManager.instance.healthBar.value = currentHealth; // Shows the updated health value on the health bar from UI manager

        if (currentHealth <= 0) // If the player's health reaches 0
        {
            GameObject deatheffect = Instantiate(playerDeathEffect, transform.position, transform.rotation); // Create a explosion effect on the player
            Destroy(deatheffect, 1f); // Destroys the death effect after a second

            GameManager.instance.KillPlayer(); // Calls the kill player function from game manager
        }

    } // End of DamagePlayer

    // Respawn player is called when the player respawns
    public void RespawnPlayer()
    {
        currentHealth = 999; // Sets the player's healh to a high value to prevent taking losing more lives
        UIManager.instance.healthBar.transform.gameObject.SetActive(false); // Disables the health bar on the UI
        UIManager.instance.respawningText.gameObject.SetActive(true); // Enables the respawning text on the UI
        GameManager.instance.respawnTime = 3; // Sets the respawn time to 3 seconds
        UIManager.instance.respawningText.text = "RESPAWNING: " + GameManager.instance.respawnTime; // Displays the remaining time until respawn to the player on the UI
        StartCoroutine(Respawn()); // Starts the Respawn coroutine
    } // End of Respawn Player Function

    IEnumerator Respawn()
    {
        while (GameManager.instance.respawnTime > 0) // While the respawn time of GameManager is greater than 0
        {
            yield return new WaitForSeconds(1); // Wait for a second
            GameManager.instance.respawnTime -= 1; // Decrease the GameManager's respawn time by 1
            UIManager.instance.respawningText.text = "RESPAWNING: " + GameManager.instance.respawnTime; // Display the new respawn time to the player on the UI
        }
        currentHealth = maxHealth; // Sets the current health to the maximum health
        UIManager.instance.healthBar.transform.gameObject.SetActive(true); // Enables the health bar on the UI
        UIManager.instance.respawningText.gameObject.SetActive(false); // Disables the respawning text on the UI
        UIManager.instance.healthBar.value = currentHealth; // Changes the health bar from UI manager to match the current health
        Shooting.instance.canFire = true; // Allows the player to fire again
    } // End of Respawn coroutine
} // End of class