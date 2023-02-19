using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassMovementRL : MonoBehaviour


{
    public GameObject leftGrass, rightGrass, player;
    public Rigidbody2D rb;
    public Rigidbody2D playerRb;
    private float speed = 3f;
    bool moveRight = true;
    bool playerMove;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRb = player.GetComponent<Rigidbody2D>();

    }


    // Update is called once per frame
    void Update()
    {
        if (moveRight)
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == leftGrass.name)
        {
            moveRight = true;
        }
        if (collision.name == rightGrass.name)
        {
            moveRight = false;
            // rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);   // moveing with the grass
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);   // stop moveing with the grass
        }
    }


} 
