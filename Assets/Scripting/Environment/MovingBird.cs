using System.Collections;
using UnityEngine;

public class MovingBird : MonoBehaviour
{
    public bool isEnabled;
    public Vector3 targetPos;
    public Vector3 defPos;
    public float delay;
    public bool isGoing = true; // mulai dari bawah ke atas
    public GameObject spawnedObject;

    void Start()
    {
        defPos = transform.position;
        targetPos = new Vector3(transform.position.x + 5f, transform.position.y, transform.position.z);
        StartCoroutine(SpawningRock());
    }
    
    IEnumerator SpawningRock()
    {
        while (isEnabled)
        {
            Debug.Log("spawning rocks");
            Instantiate(spawnedObject, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
        if (!isEnabled)
        {
            StopCoroutine(SpawningRock());
        }
        
    }

    void Update()
    {
        if (!isEnabled) return;

        if (isGoing)
        {
            // Naik ke target
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);

            if (Mathf.Abs(transform.position.x - targetPos.x) < 0.01f)
            {
                transform.position = targetPos; // snap biar pas
                isGoing = false;              // ganti arah
            }
        }
        else
        {
            // Turun ke default
            transform.position = Vector3.Lerp(transform.position, defPos, 0.1f);

            if (Mathf.Abs(transform.position.x - defPos.x) < 0.01f)
            {
                transform.position = defPos; // snap biar pas
                isGoing = true;            // ganti arah lagi
            }
        }
    }
}
