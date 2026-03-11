using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyground : MonoBehaviour
{
    private void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Player.Instance.rb.velocity.x, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("ground"))
            {
                Destroy(collision.gameObject);
            }
        }
    
}
