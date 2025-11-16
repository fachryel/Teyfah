using UnityEngine;

public class BirdArea : MonoBehaviour
{

    public MovingBird birdScr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
        void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            birdScr.isEnabled = true;
        }
    }



    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            birdScr.isEnabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
