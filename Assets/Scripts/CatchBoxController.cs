using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBoxController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float xMovementRange;
    [SerializeField] float chanceToFlipDirection;
    float direction = 1f;
    Rigidbody rgdbody;
    void Awake()
    {
        rgdbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (transform.position.x > xMovementRange && direction > 0f ||
            transform.position.x < -xMovementRange && direction < 0f)
            direction *= -1f;

        rgdbody.velocity = new Vector3(direction * speed, rgdbody.velocity.y, rgdbody.velocity.z);

        if (Random.value < chanceToFlipDirection / 100f)
            direction *= -1f;
    }
}
