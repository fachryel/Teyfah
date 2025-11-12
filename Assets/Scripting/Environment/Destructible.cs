using UnityEngine;

public class Destructible : MonoBehaviour
{
    public string destroyerTag;
    public GameObject destroyedObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == destroyerTag)
        {
            Destroy(destroyedObject);
        }
    }
}
