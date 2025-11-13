using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private PlayerHealth healthScript;
    public float health = 100f;
    private float facingDirection = 1;
    public bool canDoubleJump = false;
    public float staminaRate = 3f;
    public Rigidbody2D rb;
    public float speed = 20f;
    public float defaultSpd = 20f;
    public float maxStamina = 100f;
    public BarController staminaBar;
    public float jumpStrength = 10f;
    private Collider2D plCollider;
    public float stamina = 200f;
    public Collider2D groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;
    [SerializeField] private bool doubleJumped;
    public bool isGrounded;
    [SerializeField] private bool justJumped;
    public float dashStrength;
    public ForceMode2D forceMode2D = ForceMode2D.Force;
    [SerializeField] private bool flashHolding;
    [SerializeField] private float flashAmount;
    public AudioSource jumpSound;
    public AudioSource walkSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        plCollider = GetComponent<Collider2D>();
        healthScript = GetComponent<PlayerHealth>();


    }



    void Update()
    {
        staminaBar.UpdateBar(stamina, 100f);
        // Cek tanah
        


        // Lompat hanya kalau menyentuh tanah
        if ((Input.GetButtonDown("Jump") && isGrounded || Input.GetButtonDown("Jump") && justJumped) && Time.timeScale != 0)
        {
            
            if (isGrounded)
            {
                justJumped = true;
                doubleJumped = false;
                jumpSound.Play();
                rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            }
            else if (justJumped == true && doubleJumped == false && canDoubleJump)
            {
                if (stamina > 15f)
                {
                    StaminaChange(-15f);
                    Debug.Log("DoubleJumped");
                    justJumped = false;
                    doubleJumped = true;
                    jumpSound.Play();
                    rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
                }
            }

        }

        if (Input.GetButtonDown("Dash")  && Time.timeScale != 0)
        {
            Dash();

        }


        if (Input.GetButtonDown("Reset") )
        {
            rb.linearVelocity = Vector2.zero;
            transform.position = new Vector3(0f, 5f, 0f);
        }

        if (Input.GetButtonDown("Flash")  && Time.timeScale != 0)
        {
            flashHolding = true;

        }

        if (Input.GetButton("Flash") && flashHolding)
        {
            StaminaChange(-1f);
            flashAmount += 1f;
        }

        if (flashHolding && Input.GetButtonUp("Flash") || flashHolding && stamina <= 0)
        {

            flashHolding = false;
            FlashReleased(flashAmount);
        }

        if (Input.GetButton("Run")  && Time.timeScale != 0)
        {
            if (stamina > 0f)
            {

                speed = defaultSpd + 5f;
                StaminaChange(-1f);
            }
        }
        else if (Input.GetButton("Sprint")  && Time.timeScale != 0)
        {
            if (stamina >= 3f)
            {
                speed = defaultSpd + 10f;
                StaminaChange(-3f);
            }
        }

        if (Input.GetButtonUp("Run") || Input.GetButtonUp("Sprint"))
        {
            speedReset();
            StartCoroutine(StaminaRecharge());
        }

    }
    public bool isWalking;
    public Coroutine stepCor;




public IEnumerator WalkSound()
    {
        walkSound.Play();
        yield return new WaitUntil(() => isWalking == false);
        walkSound.Stop();
        stepCor = null;
    }


    void FixedUpdate()
    {
        // Gerakan kiri-kanan
        float moveHorizontal = Input.GetAxis("Horizontal");
        isWalking = moveHorizontal != 0f;
        if(isWalking && stepCor == null)
        {
            stepCor = StartCoroutine(WalkSound());
        }
        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y);

        //flip
        if (moveHorizontal > 0 && transform.localScale.x < 0 || moveHorizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
    }



    // public IEnumerator Dash()
    // {
    //     speed *= 2;
    //     iFrame = true;

    //     StaminaChange(-15f);
    //     yield return new WaitForSeconds(0.1f);
    //     speed /= 2;


    //     iFrame = false;
    // }



    //* Flash Group

    //Function for flipping
    public void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }

    //Function for resetting Speed
    public void speedReset()
    {
        speed = defaultSpd;
    }

    //Function for releasing Flash
    public void FlashReleased(float consumedAmount)
    {
        StartCoroutine(FlashIFrame());
        float direction = transform.localScale.x;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(new Vector2((consumedAmount * 500) * direction, 0f), forceMode2D);
        flashAmount = 0f;
        if (stamina < 0f)
        {
            stamina = 0f;
        }
        StartCoroutine(StaminaRecharge());

    }

    //Function for changing Stamina
    public void StaminaChange(float amount)
    {
        stamina += amount;

        if (amount < 0)
        {
            StartCoroutine(StaminaRecharge());
        }

    }

    //Function for Dashing
    public void Dash()
    {
        if (stamina > 25f)
        {

            StaminaChange(-25f);
            float direction = transform.localScale.x;
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(new Vector2((dashStrength * 100) * direction, 0f), forceMode2D);
        }
    }

    // //Function for Gizmo
    // void OnDrawGizmosSelected()
    // {
    //     if (groundCheck != null)
    //     {
    //         Gizmos.color = Color.yellow;
    //         Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    //     }
    // }

    //Coroutine Group

    //Coroutine for Stamina Recharging
    public IEnumerator StaminaRecharge()
    {
        while (stamina < maxStamina && !flashHolding && !Input.GetButton("Run") && !Input.GetButton("Sprint"))
        {
            StaminaChange(staminaRate);
            yield return new WaitForSeconds(1f);
        }
        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }
        if (stamina < 0f)
        {
            stamina = 0f;
        }
    }

    //Coroutine for IFrame while using Flash 
    public IEnumerator FlashIFrame()
    {
        healthScript.iFrame = true;
        yield return new WaitForSeconds(0.2f);
        healthScript.iFrame = false;
    }



}
