using UnityEngine;

public class Slippery : MonoBehaviour
{

    public float dragPower = 35f;
    PlayerMovement moveScr;
    Rigidbody2D pRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveScr = collision.gameObject.GetComponent<PlayerMovement>();
            moveScr.speed *= 0.5f;
            moveScr.jumpStrength *= 0.5f;
            pRb = collision.gameObject.GetComponent<Rigidbody2D>();
            pRb.linearDamping = dragPower;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveScr = collision.gameObject.GetComponent<PlayerMovement>();
            moveScr.speedReset();
            moveScr.jumpStrength *= 2;
            pRb.linearDamping = 0f;
        }
    }
}
