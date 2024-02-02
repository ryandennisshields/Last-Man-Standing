using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public static EndLevel instance; // Allows other scripts to use code from this script

    public int timeLeft = 120; // Stores the amount of time left before the end of level, and sets it to 120 seconds

    private string endlevel = "End Level"; // Stores the "end level" scene to be able to switch to it

    // Awake is called when the game starts
    void Awake()
    {
        instance = this; // Creates an instance of gamemanager, allowing other scripts to use it
    } // End of awake

    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.timeleftText.text = timeLeft + "s"; // Sets the "time left" text on the UI to read the time left (120 seconds)
        StartCoroutine(TimeLeft()); // Starts the TimeLeft couroutine

    } // End of Start

    // TimeLeft has been called by Start
    IEnumerator TimeLeft()
    {
        while (timeLeft > 0) // Constantly run the code while the time left is greater than 0 seconds
        {
            yield return new WaitForSeconds(1); // Wait for a second
            timeLeft -= 1; // Reduce the amount of time left 
            UIManager.instance.timeleftText.text = timeLeft + "s"; // Display the new amount of time left
        }
        SceneManager.LoadScene(endlevel); // When the time left does reach 0, load the end level scene
    } // End of TimeLeft
} // End of Class
