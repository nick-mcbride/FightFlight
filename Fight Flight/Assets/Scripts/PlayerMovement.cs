using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 200f;
    [SerializeField] float thrustSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -rotation);

        // Move the player forward
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 thrust = transform.up * thrustSpeed * Time.deltaTime;
            transform.position += thrust;
        }
    }
}

