using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Sprite> enemySprites;
    public float speed = 2f;
    public GameObject enemyLaserPrefab;
    public float shootInterval = 2f;

    private Transform player;
    private float shootTimer;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shootTimer = shootInterval;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Randomly select a sprite from the list of enemy sprites
        if (enemySprites.Count > 0)
        {
            spriteRenderer.sprite = enemySprites[Random.Range(0, enemySprites.Count)];
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
            Vector2 direction = (player.position - transform.position).normalized;
            GameObject laser = Instantiate(enemyLaserPrefab, transform.position, Quaternion.identity);

            laser.GetComponent<EnemyLaser>().SetDirection(direction);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // GameManager.instance.InitiateGameOver();
            Destroy(gameObject); 
        }
    }
}
