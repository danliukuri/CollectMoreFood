using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float xMovementRange;
    float horizontalInput;
    Rigidbody rgdbody;
    void Awake()
    {
        rgdbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        if (!(transform.position.x > xMovementRange && horizontalInput > 0f ||
            transform.position.x < -xMovementRange && horizontalInput < 0f))
            rgdbody.velocity = new Vector3(horizontalInput * speed, rgdbody.velocity.y, rgdbody.velocity.z);
    }
}
