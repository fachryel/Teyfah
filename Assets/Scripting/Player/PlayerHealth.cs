using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public int deathCount;
    public int stage;
    public float maxHealth = 100f;
    public bool iFrame;
    public Transform checkPoint;
    public Rigidbody2D rb;
    public BarController healthBar;
    public SpriteRenderer sprite;
    public Transform safeArea;
    public bool isDead;
    
    public AudioSource stage1Bgm;
    public AudioSource stage2Bgm;
    public AudioSource stage3BGm;


    public GameObject corpse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        if (stage == 1)
        {
            StartCoroutine(PlayBGM1());
        } else if (stage == 2)
        {
            StartCoroutine(PlayBGM2()); 
        } else if (stage == 3)
        {
            StartCoroutine(PlayBGM3());
        }

    }
    
     public IEnumerator PlayBGM1()
    {
        stage1Bgm.Play();
        yield return new WaitUntil(() => stage != 1);
        stage1Bgm.Stop();
        StartCoroutine(PlayBGM2());
    }

    public IEnumerator PlayBGM2()
    {
        stage2Bgm.Play();
        yield return new WaitUntil(() => stage != 2);
        stage2Bgm.Stop();
        StartCoroutine(PlayBGM3());
    }

    public IEnumerator PlayBGM3()
    {
        stage3BGm.Play();
        yield return new WaitUntil(() => stage != 3);
        stage3BGm.Stop();
    }

    public Coroutine soundCor;
    // Update is called once per frame
    void Update()
    {
        healthBar.UpdateBar(health, maxHealth);

    }
    public AudioSource hurtSound;


    //* Function Group
    //Function for changing Health
    public void HealthChange(float amount)
    {
        if (amount < 0)
        {

            hurtSound.Play();
        }
        if (!iFrame)
        {
            health += amount;
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        //go to checkpoint
        if (health <= 0f)
        {
            health = 1f;
            isDead = true;
            StartCoroutine(Died());



        }


    }



    public void ToSafe()
    {
        if (isDead)
        {
            return;
        }
        rb.linearVelocity = Vector2.zero;
        transform.position = safeArea.position;
    }
    public IEnumerator ToCheckpoint()
    {
        yield return new WaitForSeconds(0.1f);
        rb.linearVelocity = Vector2.zero;
        transform.position = checkPoint.position;
        iFrame = false;
    }


    //* Coroutine

    public AudioSource deathSound;
    //Coroutine for Died
    private bool hasSpawnedCorpse = false;

    public IEnumerator Died()
    {

        if (hasSpawnedCorpse) yield break; // cegah eksekusi ulang

        hasSpawnedCorpse = true;

        deathSound.Play();

        Instantiate(corpse, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.1f);

        ToCheckpoint();
        health = maxHealth;
        deathCount += 1;

        hasSpawnedCorpse = false;
        isDead = false; // reset supaya bisa mati lagi di masa depan
    }

}
