using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private int jumpCount = 0;
    public int maxJumps = 2;
    private Rigidbody2D rigidbody2D;
    public float speed = 10;
    public float jumpForce = 10;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Ruch w lewo/prawo
        transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * speed;

        // Animacje biegania i obracanie
        if (direction.x != 0) 
        {
            animator.SetBool("biegnie", true);

            if (direction.x < 0) 
            {
                spriteRenderer.flipX = true;
            }
            else if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
        else 
        {
            animator.SetBool("biegnie", false);
        }

        // --- NOWE: Animacje skoku i spadania! ---
        // Sprawdzamy prędkość pionową (Y) na komponencie Rigidbody2D
        if (rigidbody2D.linearVelocity.y > 0.1f) // Jeśli leci w górę
        {
            animator.SetBool("Skacze", true);
            animator.SetBool("Spada", false);
        }
        else if (rigidbody2D.linearVelocity.y < -0.1f) // Jeśli spada w dół
        {
            animator.SetBool("Skacze", false);
            animator.SetBool("Spada", true);
        }
        else // Jeśli stoi bezpiecznie na ziemi (prędkość w pionie bliska zera)
        {
            animator.SetBool("Skacze", false);
            animator.SetBool("Spada", false);
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (jumpCount < maxJumps)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = 0;
    }
}
