using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Vector2 velocity;
    private bool isGrounded;
    private float xMax;
    private Rigidbody2D rigidbody2d;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        xMax = Camera.main.orthographicSize * Camera.main.aspect;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        float inputAxis = Input.GetAxis("Horizontal");
        velocity = rigidbody2d.velocity;

        if (transform.position.x <= -xMax + 0.5f && inputAxis <= 0)
             velocity.x = 0;
        else velocity.x = inputAxis * speed;

        rigidbody2d.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGrounded && collision.gameObject.CompareTag("Ground"))
            isGrounded = collision.contacts.All(c => c.point.y < transform.position.y);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!isGrounded && collision.gameObject.CompareTag("Ground"))
            isGrounded = !collision.contacts.All(c => c.point.y > transform.position.y);
    }

    private void Jump()
    {
        rigidbody2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
}
