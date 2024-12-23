using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.AddPoints(10); // Add points
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}



