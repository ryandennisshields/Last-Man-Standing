using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public static Shooting instance; // Allows other scripts to use code from Shooting

    public Transform firePoint; // Stores the position of the firing point
    public GameObject bullet; // Stores the bullet 

    private float bulletSpeed = 20f; // Stores the speed of the bullet and sets it to 20

    public bool canFire = true; // Stores a bool that decides if the player can fire or not and sets it to true

    // Awake is called at the start of the program
    void Awake()
    {
        instance = this; // Allows other scripts to use code from Shooting
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire == true)
        {
            if (Input.GetButtonDown("Fire1")) // Checks if the player fires (left-click)
            { // If the player fires (left-click),
                StartCoroutine(Shoot()); // Call the shoot coroutine
            }
        }
    } // End of Update

    // Called whenever the player fires (left-click)
    IEnumerator Shoot()
    {
        canFire = false; // Sets can fire to false
        GameObject PlayerShot = Instantiate(bullet, firePoint.position, firePoint.rotation); // Sets the bullet to the position and rotation of the firepoint
        Rigidbody2D rb = PlayerShot.GetComponent<Rigidbody2D>(); // Gets the rigidbody of the bullet
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse); // Takes the rigidbody of the bullet and applies force to it, coming out upwards from the fire point
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
        canFire = true; // Sets can fire to false
    } // End of Shoot
} // End of class
