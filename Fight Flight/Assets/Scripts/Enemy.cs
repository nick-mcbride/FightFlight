using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //game manager needs to set up first
            //GameManager.instance.InitiateGameOver();
        }
        else
        {
            //GameManager.instance.IncreaseScore(10);
        }
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
