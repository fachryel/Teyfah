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
    public Collider2D triggerArea;

    public float targetX;

    void Start()
    {
        defPos = transform.position;
        targetPos = new Vector3(transform.position.x + targetX, transform.position.y, transform.position.z);
        StartCoroutine(SpawningRock());
    }

    IEnumerator SpawningRock()
    {
        while (isEnabled)
        {
            Debug.Log("spawning rocks");
            Instantiate(spawnedObject, new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
        if (!isEnabled)
        {
            StopCoroutine(SpawningRock());
            rockCor = null;
        }

    }

    private Coroutine rockCor;

    public float spd;




    void Update()
    {

        if(isEnabled && rockCor == null)
        {
            rockCor = StartCoroutine(SpawningRock());


        }
        if (!isEnabled) return;

        if (isGoing)
        {
            // Naik ke target
            transform.position = Vector3.Lerp(transform.position, targetPos, spd);

            if (Mathf.Abs(transform.position.x - targetPos.x) < 0.5f)
            {
                transform.position = targetPos; // snap biar pas
                isGoing = false;              // ganti arah
            }
        }
        else
        {
            // Turun ke default
            transform.position = Vector3.Lerp(transform.position, defPos, spd);

            if (Mathf.Abs(transform.position.x - defPos.x) < 0.5f)
            {
                transform.position = defPos; // snap biar pas
                isGoing = true;            // ganti arah lagi
            }
        }
    }
}
