using UnityEngine;

public class MovingLava : MonoBehaviour
{
    public bool isEnabled;
    public Vector3 targetPos;
    public Vector3 defPos;
    public bool isGoingUp = true; // mulai dari bawah ke atas

    void Start()
    {
        defPos = transform.position;
        targetPos = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
    }

    void Update()
    {
        if (!isEnabled) return;

        if (isGoingUp)
        {
            // Naik ke target
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);

            if (Mathf.Abs(transform.position.y - targetPos.y) < 0.01f)
            {
                transform.position = targetPos; // snap biar pas
                isGoingUp = false;              // ganti arah
            }
        }
        else
        {
            // Turun ke default
            transform.position = Vector3.Lerp(transform.position, defPos, 0.1f);

            if (Mathf.Abs(transform.position.y - defPos.y) < 0.01f)
            {
                transform.position = defPos; // snap biar pas
                isGoingUp = true;            // ganti arah lagi
            }
        }
    }
}
