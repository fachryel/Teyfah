using UnityEngine;

public class Coin : MonoBehaviour
{
    public float amount;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            Destroy(gameObject);
            collision.GetComponent<Resource>().coin+=amount;
        }
    }
}
