using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Sprite> enemySprites;
    public float speed = 2f;
    public GameObject enemyLaserPrefab;
    public float shootInterval = 3f;
    public Transform firePoint;

    private Transform player;
    private float shootTimer;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shootTimer = shootInterval;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (enemySprites.Count > 0)
        {
            spriteRenderer.sprite = enemySprites[Random.Range(0, enemySprites.Count)];
        }

        if (GameManager.instance == null)
        {
            Debug.LogError("GameManager instance is null in Enemy.Start");
        }
    }

    void Update()
    {
        MoveTowardsPlayer();
        HandleShooting();
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }

    void HandleShooting()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootInterval;
        }
    }

    void Shoot()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - firePoint.position).normalized;
            GameObject laser = Instantiate(enemyLaserPrefab, firePoint.position, Quaternion.identity);
            laser.GetComponent<EnemyLaser>().SetDirection(direction);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.TakeDamage(1); // Take 1 damage
            }
            else
            {
                Debug.LogError("GameManager instance is null in Enemy.OnTriggerEnter2D");
            }
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.AddPoints(10); // Add points when enemy is destroyed
        }
    }
}



