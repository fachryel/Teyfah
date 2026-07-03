using UnityEngine;
using System.Collections;

public class Selfdestruct : MonoBehaviour
{
    public float delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SelfDestruct(delay));
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public IEnumerator SelfDestruct(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    
}
