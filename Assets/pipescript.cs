using UnityEngine;

public class pipescript : MonoBehaviour
{
    public float moveSpeed = 5; // Speed at which the pipes move to the left
    public float deadZone = -45; // X position at which the pipe is destroyed

    // Update is called once per frame
    void Update()
    {
        MovePipe(); // Move the pipe to the left
        CheckForDestruction(); // Check if the pipe should be destroyed
    }

    // Moves the pipe to the left based on moveSpeed
    private void MovePipe()
    {
        // Move the pipe to the left using Translate
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    // Checks if the pipe has reached the dead zone and destroys it if necessary
    private void CheckForDestruction()
    {
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject); // Destroy the pipe when it goes beyond the dead zone
        }
    }
}