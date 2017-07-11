/*
 * 
 * Author: Spencer Wilson
 * Date Created: 7/5/2017
 * Last Modified: 7/5/2017, 10:12 pm
 * File: movePlayer.cs
 * Description: Contains the code that allows the player to move around as well as jump.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour {

    public float moveSpeed; // Allows us to control the speed of the player from the inspector panel.
    public float currentSpeed; // Variable that holds the current speed of the player.
    public float speedLimit; // Holds the speed limit for the player when moving normally.
    public float jumpHeight; // Variable that will hold the amount that determines how high the player can jump.
    private Rigidbody2D playerRigidbody; // Rigidbody2D gameobject to hold the player

	// Use this for initialization
	void Start () {
        moveSpeed = 30f; // Assigning moveSpeed an initial value.
        speedLimit = 1f; // Holds the speed limit for the player.
        playerRigidbody = GetComponent<Rigidbody2D>(); // Getting the Rigidbody2D component of the player.
        currentSpeed = playerRigidbody.velocity.magnitude;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        PlayerMovement(); // Calls upon the PlayerMovement() function.
        PlayerJump(); // Calls upon the PlayerJump() function.
	}

    void PlayerMovement() // Function that allows the player to move left and right.
    {

        if (Input.GetKey("a"))
        {
            if (currentSpeed < speedLimit) // If the player's speed is less than the speed limit, increase the player's speed. (Find out for only the x-axis or when traveling to the right or left?
            {
                playerRigidbody.AddForce(transform.right * moveSpeed * -10f);
                Debug.Log("Moving to the left.");
            }
        }
        if (Input.GetKeyUp("a"))
        {
            Debug.Log("Standing still.");
        }
        if (Input.GetKey("d"))
        {
            playerRigidbody.AddForce(transform.right * moveSpeed * 10f);
            Debug.Log("Moving to the right.");
        }
        if (Input.GetKeyUp("d"))
        {
            Debug.Log("Standing still");
        }
        //else
        //{
        //    Debug.Log("Player is standing still.");
        //}
    }

    void PlayerJump() // Function that holds the code that makes players jump.
    {
        bool jumpKey = Input.GetKey("space");

        if (jumpKey == true) {
            Debug.Log("Player is jumping.");
        }
        else
        {
            Debug.Log("Player is not jumping.");
        }
    }
}
