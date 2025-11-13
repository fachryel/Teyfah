using System.Collections;
using UnityEngine;

public class FallingThing : MonoBehaviour
{

    public Collider2D objectCollider;
    public BoxCollider2D triggerArea;
    public float damage = 5f;
    public LayerMask pLayer;
    public Rigidbody2D rb;
    public PlayerHealth healthScript;
    public AudioSource rockDestroy;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();

        triggerArea = GetComponentInChildren<BoxCollider2D>();
        //find objeck with RockDestroy tag
        rockDestroy = GameObject.FindWithTag("RockDestroy").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        pLayer = LayerMask.GetMask("Player");

        healthScript = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerArea.IsTouchingLayers(pLayer))
        {
            rb.gravityScale = 10f;
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }

        if (objectCollider.IsTouchingLayers(pLayer))
        {
            DamagePlayer();
        }
    }

    public  IEnumerator DestroyCountdown()
    {
        rockDestroy.Play();
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }



    public void DamagePlayer()
    {
        healthScript.HealthChange(-damage);
        Destroy(gameObject);
    }
}
