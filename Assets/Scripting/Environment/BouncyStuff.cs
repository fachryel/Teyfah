using UnityEngine;

public class BouncyStuff : MonoBehaviour
{


    public Collider2D triggerArea;
    public float bouncePower;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        triggerArea = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>(); 
            rb.AddForce(Vector2.up * bouncePower, ForceMode2D.Impulse);
        }
    }
}
