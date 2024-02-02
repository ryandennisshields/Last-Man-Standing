using System.Collections;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public static EnemyGeneration instance; // Stores this code as an instance, to allow other code to use it
    
    public GameObject Spikey; // Stores the "Spikey" enemy
    public GameObject Shooty; // Stores the "Shooty" enemy

    public Transform spawnPoint1; // Stores the first spawn point
    public Transform spawnPoint2; // Stores the second spawn point
    public Transform spawnPoint3; // Stores the third spawn point
    public Transform spawnPoint4; // Stores the fourth spawn point

    private bool spawnOn; // Stores a bool for if spawning is on or not
    private int spawnTime; // Stores the amount of time before spawning an enemy
    public int enemyCount; // Stores the amount of enemies currently spawned
    public int enemyCountMax; // Stores the maximum amount of enemies that can spawn
    private int enemyspawnChoice; // Stores the number deciding the spawn choice (what enemy to spawn, and where to spawn it)


    // Start is called before the first frame update
    void Start()
    {
        instance = this; // Creates an instance of this code, allowing other code to use it
        StartCoroutine(EnemySpawn()); // Starts the EnemySpawn coroutine
    }

    // FixedUpdate is called every fixed framerate frame
    private void FixedUpdate()
    {
        if (enemyCount < enemyCountMax) // Checks if the enemy count is less than 12
        { // If the enemy count is less than 12,
            if (spawnOn == true) // Also checks if the spawns are on
            { // If spawning is on,
                StartCoroutine(EnemySpawn()); // Starts the EnemySpawn coroutine
            }
            else
            { // If spawning is off,
                StopCoroutine(EnemySpawn()); // Stop the EnemySpawn coroutine
                spawnOn = false; // Make sure that spawning is off for sure
            }
        }
    }

    // Called at the start of the program, and whenever spawning is on
    // Calling stopped whenever spawning is off
    IEnumerator EnemySpawn()
    {
        spawnOn = true; // Sets spawning on
        if (EndLevel.instance.timeLeft >= 80)
        { // If the time left is greater than or equal to 80,
            spawnTime = Random.Range(2, 3); // Sets spawnTime to a random number between and including 4 and 6
            enemyCountMax = 10; // Sets the maximum amount of enemies to 10
        }
        if (EndLevel.instance.timeLeft >= 40 && EndLevel.instance.timeLeft <= 80)
        { // If the time left is greater than or equal to 40 and less than or equal to 80,
            spawnTime = Random.Range(1, 2); // Sets spawnTime to a random number between and including 2 and 4
            enemyCountMax = 15; // Sets the maximum amount of enemies to 15
        }
        if (EndLevel.instance.timeLeft >= 0 && EndLevel.instance.timeLeft <= 40)
        { // If the time left is greater than or equal to 0 and less than or equal to 40,
            spawnTime = Random.Range(0, 1); // Sets spawnTime to a random number between and including 1 and 2
            enemyCountMax = 20; // Sets the maximum amount of enemies to 20
        }
        enemyspawnChoice = Random.Range(1, 8); // Sets the spawn choice to a random number between and including 1 and 6
        if (enemyspawnChoice == 1) // Check if the enemy spawn choice is equal to 1
        { // If the spawn choice is equal to 1,
            Instantiate(Spikey, spawnPoint1.position, spawnPoint1.rotation); // Spawn the "Spikey" enemy at spawn point 1
        }
        if (enemyspawnChoice == 2) // Check if the enemy spawn choice is equal to 2
        { // If the spawn choice is equal to 2,
            Instantiate(Shooty, spawnPoint1.position, spawnPoint1.rotation); // Spawn the "Shooty" enemy at spawn point 1
        }
        if (enemyspawnChoice == 3) // Check if the enemy spawn choice is equal to 3
        { // If the spawn choice is equal to 3,
            Instantiate(Spikey, spawnPoint2.position, spawnPoint2.rotation); // Spawn the "Spikey" enemy at spawn point 2 
        }
        if (enemyspawnChoice == 4) // Check if the enemy spawn choice is equal to 4
        { // If the spawn choice is equal to 4,
            Instantiate(Shooty, spawnPoint2.position, spawnPoint2.rotation); // Spawn the "Shooty" enemy at spawn point 2  
        }
        if (enemyspawnChoice == 5) // Check if the enemy spawn choice is equal to 5
        { // If the spawn choice is equal to 5,
            Instantiate(Spikey, spawnPoint3.position, spawnPoint3.rotation); // Spawn the "Spikey" enemy at spawn point 3  
        }
        if (enemyspawnChoice == 6) // Check if the enemy spawn choice is equal to 6
        { // If the spawn choice is equal to 6,
            Instantiate(Shooty, spawnPoint3.position, spawnPoint3.rotation); // Spawn the "Shooty" enemy at spawn point 3
        }
        if (enemyspawnChoice == 7) // Check if the enemy spawn choice is equal to 7
        { // If the spawn choice is equal to 7,
            Instantiate(Spikey, spawnPoint4.position, spawnPoint4.rotation); // Spawn the "Spikey" enemy at spawn point 4 
        }
        if (enemyspawnChoice == 8) // Check if the enemy spawn choice is equal to 8
        { // If the spawn choice is equal to 8,
            Instantiate(Shooty, spawnPoint4.position, spawnPoint4.rotation); // Spawn the "Shooty" enemy at spawn point 4 
        }
        enemyCount += 1; // Increase the enemy count by 1
        spawnOn = false; // Turn spawning off
        yield return new WaitForSecondsRealtime(spawnTime); // Wait for a few seconds depending on the randomly chosen spawn time
        spawnOn = true; // Turn spawning on
    } // End of EnemySpawn
} // End of class
