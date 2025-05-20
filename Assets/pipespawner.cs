using UnityEngine;

public class pipespawner : MonoBehaviour
{
    public GameObject pipe; // Reference to the pipe prefab
    public float spawnrate = 2; // Time interval between pipe spawns
    public float heightOffset = 10; // Vertical range for randomizing pipe height

    private float timer = 0; // Timer to track spawn intervals

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe(); // Spawn the first pipe immediately
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer(); // Update the spawn timer
    }

    // Updates the timer and spawns a pipe when the timer reaches the spawn rate
    private void UpdateTimer()
    {
        if (timer < spawnrate)
        {
            timer += Time.deltaTime; // Increment the timer
        }
        else
        {
            SpawnPipe(); // Spawn a new pipe
            timer = 0; // Reset the timer
        }
    }

    // Spawns a pipe at a random height within the specified range
    private void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset; // Calculate the lowest possible Y position
        float highestPoint = transform.position.y + heightOffset; // Calculate the highest possible Y position

        // Instantiate the pipe at a random height within the range
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}