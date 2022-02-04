using GameHandlers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float xMovementRange;
    const float defaultHorizontalInputValue = 0;
    float horizontalInput;
    Rigidbody rgdbody;
    void Awake()
    {
        rgdbody = GetComponent<Rigidbody>();
    }
    public void Reset()
    {
        horizontalInput = defaultHorizontalInputValue;
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