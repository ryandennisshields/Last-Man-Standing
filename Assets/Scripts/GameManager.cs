using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; // Allows other scripts to use code from this script

    public int currentLives = 3; // Stores the current lives

    public int respawnTime = 3; // Stores the amount of time before respawning the player

    public int currentScore; // Stores the current score

    public int powerupHP; // Stores the extra HP the power-up offers

    public AudioSource powerupLoss; // Stores the sound of losing the power up

    // Awake is called when the program loads
    void Awake()
    {
        instance = this; // Creates an instance of gamemanager, allowing other scripts to use it
    } // End of awake

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // Sets the time scale to 1 (plays the game at normal speed)
        UIManager.instance.livesText.text = "X " + currentLives; // Displays the current lives from the UI manager
        UIManager.instance.scoreText.text = "" + currentScore; // Displays the current score from the UI manager
        UIManager.instance.respawningText.text = "RESPAWNING: " + respawnTime; // Displays the amount of time until the player respawns from the UI manager
    } // End of start

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        { // If the player presses the ESC key,
            if (currentLives > 0)
            { // If current lives are greater than 0,
                PauseGame(); // Run the Pause Game function
            }
        }
    } // End of update

    // Called whenever the player presses the ESC key
    public void PauseGame()
    {
        Time.timeScale = 0; // Sets the time scale to 0 (freezes the game)
        PlayerMovement.instance.enabled = false; // Disables the player, making them unable to do anything
        Shooting.instance.enabled = false; // Disables the ability to shoot
        UIManager.instance.pauseScreen.SetActive(true); // Enables the pause screen
    } // End of pausegame

    // Called when the player loses all health
    public void KillPlayer()
    {
        currentLives--; // Removes a life
        UIManager.instance.livesText.text = "X " + currentLives; // Re-displays the lives after one is lost

        if (currentLives > 0)
        { // If current lives is greater than 0,
            HealthManager.instance.RespawnPlayer(); // Respawns the player using the health manager
        }
        else
        { // If lives are not greater than 0,
            GameObject Player = GameObject.FindGameObjectWithTag("Player"); // Finds a game object with the tag "Player"
            Player.SetActive(false);  // Sets the player false so the player can't do anything
            UIManager.instance.gameOverscreen.SetActive(true); // Displays the game over screen
            Time.timeScale = 0; // Sets the time scale to 0 (freezes the game)
        }

    } // End of Kill Player function

    // The coroutine for adding score
    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd; // Adds on the score to the current score
        UIManager.instance.scoreText.text = "" + currentScore; // Displays the current score after being updated
    } // End of addscore

    // Called every fixed framerate frame
    private void FixedUpdate()
    {
        if (powerupHP > HealthManager.instance.currentHealth) // Checks if the power up HP is greater than the HealthManager's current health
        { // If power up HP is greater than the current health,
            PowerUp.instance.spriteRenderer.sprite = PowerUp.instance.normalSprite; // Change the effected player's sprite back to the normal sprite from the PowerUp
            powerupLoss.Play(); // Plays the sound of losing the power up
            PowerUpGeneration.instance.powerupCount -= 1; // Takes one away from the powerupcount from Power Up Generation (to allow another powerup to spawn)
            powerupHP = 0; // Set the power up HP to 0
        }
    } // End of fixed update
} // End of class
