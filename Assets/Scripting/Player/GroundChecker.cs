using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    public Collider2D groundCheck;
    public PlayerMovement movementScript;
    // public LayerMask groundLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Solid")
        {
            movementScript.isGrounded = true;

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Solid")
        {
            movementScript.isGrounded = false;

        }
    }
}
