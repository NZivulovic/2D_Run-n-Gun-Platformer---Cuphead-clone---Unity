using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;

    private float move_x = 0;
    private float move_y = 0;

    private bool has_dash = false;
    private bool is_grounded = false;

    private Vector2 thrust;
    [SerializeField] private float jump_height = 2;
    [SerializeField] private float move_speed = 10;

    void Awake()
    {
        thrust = new Vector2(1,jump_height);
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        HandleMovement();

    }

    private void HandleMovement()
    {
        float move_x = Input.GetAxisRaw("Horizontal");
        // float move_y = Input.GetAxisRaw("Vertical");

        // rb.linearVelocity = new Vector2(move_x * move_speed, rb.linearVelocityY);
        // rb.linearVelocity = new Vector2(rb.linearVelocityX, move_y * move_speed);
        if (is_grounded)
        {
            rb.linearVelocity = new Vector2(move_x * move_speed, rb.linearVelocityY);
            has_dash = false;
        }

        if (is_grounded && Input.GetKey(KeyCode.Space)) 
        {
            rb.AddForce(thrust, ForceMode2D.Impulse);
            move_x = 0;
            has_dash = false;
        }

        else if (is_grounded == false && has_dash)
        {
            if (move_x > 0 && Input.GetKey(KeyCode.Space))
            {
                rb.linearVelocity = new Vector2(move_x += 10, rb.linearVelocityY);
                has_dash = false;
            }
            else if (move_x < 0 && Input.GetKey(KeyCode.Space))
            {
                rb.linearVelocity = new Vector2(move_x -= 10, rb.linearVelocityY);
                has_dash = false;
            }
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            is_grounded = true;
            has_dash = false;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            is_grounded = false;
            has_dash = true;
        }
    }
}
