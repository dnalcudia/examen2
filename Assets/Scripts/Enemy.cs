using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;

    [SerializeField]
    public int health = 1;

    [SerializeField]
    float speed = 1;

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        GameObject[] spawnPoints =
            GameObject.FindGameObjectsWithTag("SpawnPoint");
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[randomSpawnPoint].transform.position;
    }

    private void Update()
    {
        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3) direction * Time.deltaTime * speed;

        if (health == 0)
        {
            Destroy (gameObject);
        }
    }

    public void TakeDamage()
    {
        health--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage();
        }
    }
}
