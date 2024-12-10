using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hlu : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D rb2d;
    void Start()
    {
      rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = new Vector2(5.0f, 5.0f);
        rb2d.velocity = moveDirection * moveSpeed;
    }
}
