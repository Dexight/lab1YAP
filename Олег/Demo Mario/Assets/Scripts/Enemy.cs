using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rigidbody2d;
    private Vector2 direction = Vector2.left;

    private float xMax;

    private Player player;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        xMax = Camera.main.orthographicSize * Camera.main.aspect;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rigidbody2d.velocity = direction * speed;
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if (transform.position.x < -xMax + 0.5f || transform.position.x > xMax - 0.5f)
            ChangeDirection(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bool dead = collision.contacts.All(c => c.point.y > transform.position.y);
            if (dead || player.StarPower)
            {
                Destroy(gameObject);
            }
            else
            {
                GameManager.instance.isFromTube = false;
                GameManager.instance.score = 0;
                SceneManager.LoadScene(3);
            }
        }
        else ChangeDirection(!collision.contacts.All(c => c.point.y < transform.position.y));
    }

    private void ChangeDirection(bool makeChange)
    {
        if (makeChange)
        {
            direction = -direction;
            Vector2 velocity = rigidbody2d.velocity;
            velocity.x = direction.x * speed;
            rigidbody2d.velocity = velocity;
        }
    }
}
