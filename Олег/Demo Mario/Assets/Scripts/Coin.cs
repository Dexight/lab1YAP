using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int count;

    [SerializeField] private AudioClip audioClip;
    private GameObject player;
    private AudioSource audioSource;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().AddCoin(count);
            audioSource.PlayOneShot(audioClip);
            Destroy(gameObject);
        }
    }
}
