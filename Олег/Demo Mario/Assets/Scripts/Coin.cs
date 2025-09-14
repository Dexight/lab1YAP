using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int count;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().AddCoin(count);
            Destroy(gameObject);
        }
    }
}
