using UnityEngine;

public class SlipSurface : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.rigidbody;
        if (rb != null && collision.collider.CompareTag("Player"))
        {
            Debug.Log("Anjayani");
            // Kurangi kontrol horizontal saat di atas permukaan ini
            Vector2 vel = rb.linearVelocity;
            vel.x *= 0.2f; // semakin kecil = semakin licin (misal 0.9f → agak licin, 0.98f → sangat licin)
            rb.linearVelocity = vel;
        }
    }
}
