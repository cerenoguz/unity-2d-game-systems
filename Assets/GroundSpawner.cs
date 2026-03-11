using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject Ground1, Ground2, Ground3;
    bool hasGround = true;
    public static GroundSpawner instance;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Player.Instance.rb.velocity.x, 0);
        if (!hasGround)
        {
            SpawnGround();
            hasGround = true;
        }
    }

    public void SpawnGround()
    {
        int randomNumber = Random.Range(1, 4);
        if (randomNumber == 1)
        {
            Instantiate(Ground1, new Vector3(transform.position.x  - 5, 0, 0), Quaternion.identity);
        }
        if(randomNumber == 2)
        {
            Instantiate(Ground2, new Vector3(transform.position.x - 5, 1.40f, 0), Quaternion.identity);
        }
        if (randomNumber == 3)
        {
            Instantiate(Ground3, new Vector3(transform.position.x - 5, 2.8f, 0), Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            hasGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            hasGround = false;
        }
    }
}
