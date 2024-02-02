using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance; // Creates an instance of PlayerMovement, allowing other scripts to use it

    public float moveSpeed = 5f; // Stores the move speed and sets it to 5

    public Rigidbody2D rb; // Stores the rigidbody of the player
    public Camera cam; // Stores the camera position 

    Vector2 movement; // Stores the movement of the player
    Vector2 mousePos; // Stores the mouse position
                      
    // Awake is called when the game starts
    void Awake()
    {
        instance = this; // Creates an instance of PlayerMovement, allowing other scripts to use it
    } // End of awake

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // Allows the player to move along the X plane using horizontal inputs (A and D)
        movement.y = Input.GetAxisRaw("Vertical"); // Allows the player to move along the Y plane using vertical inputs (W and S)

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); // Makes the player rotate towards the mouse position when the mouse is moved
    } // End of Update

    // Called every fixed framerate frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // Changes the player's position dependant on move speed

        Vector2 lookDir = mousePos - rb.position; // Sets the look direction of the player
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f; // An equation is used to figure out the angle of rotation the player will turn
        rb.rotation = angle; // Changes the player's rotation after it's been calculated
    } // End of FixedUpdate
} // End of class
