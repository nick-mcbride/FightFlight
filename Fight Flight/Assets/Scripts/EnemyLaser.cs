using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;

    void Update()
    {
        // Move in the assigned direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        // Rotate laser to face in the movement direction
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Add logic for damaging the player here
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        //else if (collision.CompareTag("Boundary")) // Optional: destroy if hits screen boundary
        //{
        //    Destroy(gameObject);
        //}
    }
}
