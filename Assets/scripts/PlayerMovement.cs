using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public Rigidbody2D rb;
    [HideInInspector]
    public static float FishSize;
    Vector2 movement;
    void Start()
    {
        FishSize = 0.8f;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x > 0)
        {
            transform.localScale = new Vector2(FishSize, FishSize);

        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector2(-FishSize, FishSize);
        }

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime);
    }
}
