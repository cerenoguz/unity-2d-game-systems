using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallMovement : MonoBehaviour
{
    Rigidbody2D rb2d; 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.velocity = new Vector2(Player.Instance.rb.velocity.x, 0);
    }
}
