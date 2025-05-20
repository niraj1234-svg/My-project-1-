using UnityEngine;

public class middle : MonoBehaviour
{
    public logic logic; // Reference to the logic script

    // Start is called before the first frame update
    void Start()
    {
        FindLogicScript(); // Find and assign the logic script
    }

    // Finds and assigns the logic script component
    private void FindLogicScript()
    {
        GameObject logicObject = GameObject.FindGameObjectWithTag("Logic");
        if (logicObject != null)
        {
            logic = logicObject.GetComponent<logic>();
            if (logic == null)
            {
                Debug.LogError("The GameObject with tag 'Logic' does not have a logicscript component.");
            }
        }
        else
        {
            Debug.LogError("No GameObject with tag 'Logic' found in the scene.");
        }
    }

    // Called when another object enters the trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) // Check if the colliding object is on the "Player" layer
        {
            if (logic != null)
            {
                logic.addScore(1); // Add score
            }
            else
            {
                Debug.LogWarning("Logic script reference is not assigned.");
                FindLogicScript(); // Attempt to find the logic script again
                if (logic != null)
                {
                    logic.addScore(1); // Try to add score again
                }
                else
                {
                    Debug.LogError("Failed to find Logic script after retry.");
                }
            }
        }
    }
}