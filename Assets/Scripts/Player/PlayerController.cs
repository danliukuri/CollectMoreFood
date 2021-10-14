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
        InputHandler.GetHorizontalAxis(ref horizontalInput);
    }
    void FixedUpdate()
    {
        if (horizontalInput != 0)
            if (!(transform.position.x > xMovementRange && horizontalInput > 0f || // if goes to left
                transform.position.x < -xMovementRange && horizontalInput < 0f)) // if goes to right
                rgdbody.velocity = new Vector3(horizontalInput * speed, rgdbody.velocity.y, rgdbody.velocity.z);
    }
}
