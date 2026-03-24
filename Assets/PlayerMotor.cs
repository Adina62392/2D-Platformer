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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * speed;
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
