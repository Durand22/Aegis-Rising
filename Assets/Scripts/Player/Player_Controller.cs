using UnityEngine;
using UnityEngine.UI; // Required for working with UI elements

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Vector2 moveInput; 
    
    [Header("Movement Settings")]
    public float moveSpeed = 7f;
    
    [Header("Dash Settings")]
    public float dashSpeed = 15f;
    public float dashTime = 0.2f;
    public float dashCooldown = 1f;
    private float dashCounter;
    private float dashCooldownCounter;
    private bool isDashing;

    [Header("UI Reference")]
    [SerializeField] private Image dashCooldownImage; // Drag your UI Image here in the Inspector

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();  
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()   
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(movex, movey).normalized;

        anim.SetFloat("Speed", moveInput.magnitude);

        // --- X FLIP & Y ROTATE LOGIC ---
        if (moveInput != Vector2.zero)
        {
            if (moveInput.x > 0)
                spriteRenderer.flipX = false; 
            else if (moveInput.x < 0)
                spriteRenderer.flipX = true;  

            if (moveInput.y > 0)
            {
                float tiltAngle = spriteRenderer.flipX ? -20f : 20f;
                transform.rotation = Quaternion.Euler(0, 0, tiltAngle);
            }
            else if (moveInput.y < 0)
            {
                float tiltAngle = spriteRenderer.flipX ? 20f : -20f;
                transform.rotation = Quaternion.Euler(0, 0, tiltAngle);
            }
            else
            {
                transform.rotation = Quaternion.identity; 
            }
        }

        // --- DASH TIMERS & COOLDOWN UI ---
        if (dashCooldownCounter > 0)
        {
            dashCooldownCounter -= Time.deltaTime;

            // Update Radial UI Fill (goes from 1 down to 0 as cooldown finishes)
            if (dashCooldownImage != null)
            {
                dashCooldownImage.fillAmount = dashCooldownCounter / dashCooldown;
            }
        }
        else
        {
            // Ensure UI is fully ready when cooldown hits 0
            if (dashCooldownImage != null && dashCooldownImage.fillAmount > 0)
            {
                dashCooldownImage.fillAmount = 0f; // Or 1f depending on whether fill represents empty or full
            }
        }

        if (isDashing)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                isDashing = false;
                anim.SetBool("IsDashing", false);
            }
            return;
        }

        // Trigger Dash
        if (Input.GetKeyDown(KeyCode.Space) && dashCooldownCounter <= 0 && moveInput != Vector2.zero)
        {
            isDashing = true;
            anim.SetBool("IsDashing", true);
            dashCounter = dashTime;
            dashCooldownCounter = dashCooldown;

            if (dashCooldownImage != null)
            {
                dashCooldownImage.fillAmount = 1f; // Snap to full when triggered
            }
        }
    }

    private void FixedUpdate()  
    {
        if (!isDashing)
        {
            rb.MovePosition(rb.position + moveInput * (moveSpeed * Time.fixedDeltaTime));
        }
        else
        {
            rb.MovePosition(rb.position + moveInput * (dashSpeed * Time.fixedDeltaTime));
        }
    }
}