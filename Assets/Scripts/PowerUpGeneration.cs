using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGeneration : MonoBehaviour
{
    public static PowerUpGeneration instance; // Allows other scripts to use PowerUpGeneration's code

    public GameObject PowerUp; // Stores the power-up game object

    public Transform spawnPoint; // Stores the position of the spawn point

    private bool spawnOn; // Stores a bool for if spawning is on or not
    private int spawnTime; // Stores the amount of time before spawning a power-up
    public int powerupCount; // Stores the amount of power-ups active


    // Start is called before the first frame update
    void Start()
    {
        instance = this; // Allows other scripts to use PowerUpGeneration's code

        StartCoroutine(PowerUpSpawn()); // Start the PowerUpSpawn coroutine
    }

    // FixedUpdate is called every fixed framerate frame
    private void FixedUpdate()
    {
        if (powerupCount < 1) // Checks if the power up count is less than 1
        { // If the power up count is less than 1,
            if (spawnOn == true) // Also checks if the spawns are on
            { // If spawning is on,
                StartCoroutine(PowerUpSpawn()); // Starts the PowerUpSpawn coroutine
            }
            else
            { // If spawning is off,
                StopCoroutine(PowerUpSpawn()); // Stop the EnemySpawn coroutine
                spawnOn = false; // Make sure that spawning is off for sure
            }
        }
    }

    // Called at the start of the program, and whenever spawning is on
    // Calling stopped whenever spawning is off
    IEnumerator PowerUpSpawn()
    {
        spawnTime = Random.Range(30, 60); // Sets the spawn time to a random number between and including 30 and 60
        spawnOn = false; // Turns spawning off
        yield return new WaitForSecondsRealtime(spawnTime); // Waits for the amount of set spawn time
        Instantiate(PowerUp, spawnPoint.position, spawnPoint.rotation); // Spawns the power-up in the spawn point's position
        powerupCount += 1; // Adds one to the power up count
        spawnOn = true; // Turns spawning on
    }
}
