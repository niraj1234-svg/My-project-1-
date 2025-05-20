using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class birdscript : MonoBehaviour
{
    public Rigidbody2D myRigidbody; // Reference to the bird's Rigidbody2D component
    public float flapoffset; // Force applied when the bird flaps
    public bool birdIsAlive = true; // Tracks whether the bird is alive
    public logic gameLogic; // Reference to the logic script to handle game over

    // Start is called before the first frame update
    void Start()
    {
        // Find the logic object in the scene and get its logic component
        gameLogic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logic>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for spacebar input and if the bird is alive
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            // Apply upward force to the bird
            myRigidbody.linearVelocity = Vector2.up * flapoffset;
        }

        // Optional: Restart the game when the bird dies and the player presses a key
        if (!birdIsAlive && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Called when the bird collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive) // Ensure the bird is still alive before triggering game over
        {
            gameLogic.gameOver(); // Call the game over method in the logic script
            birdIsAlive = false; // Set the bird's alive status to false
        }
    }
}