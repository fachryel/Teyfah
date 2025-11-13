using UnityEngine;

public class Explosive : MonoBehaviour
{

    public float blastRadius = 5f;
    public Transform blastPoint;
    public LayerMask ppLayer;
    public PlayerHealth healthScript;
    public AudioSource Explosound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthScript = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        Explosound = GameObject.FindWithTag("Explosound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Solid" || collision.gameObject.tag == "Player")
        {
            CheckForPlayer();
            Explosound.Play();
            Destroy(gameObject);
        }
    }

    void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(blastPoint.position, blastRadius, ppLayer);
        if (hits.Length > 0)
        {
            healthScript.HealthChange(-10f);
        }
        //play sound

    }

       private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(blastPoint.position, blastRadius);
    }
}
