using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemiesMovement : MonoBehaviour
{

    public GameObject tiles;
    public Rigidbody2D rb;
    public GameObject gameOverPanel;
    private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
       // width = tiles.GetComponent<Collider>().bounds.size.x
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Saw")
        {
            transform.Rotate(0, 0, speed);
        }
        

        if (transform.position.x <= tiles.transform.position.x - tiles.transform.localScale.x)
        {
              rb.velocity = new Vector2(speed, rb.velocity.y);
            // rb.velocity += Vector2.right * 1;
            //transform.Translate(Vector2.right * 0.1f);
        }
        else if (transform.position.x >= tiles.transform.position.x + tiles.transform.localScale.x)
        {
             rb.velocity = new Vector2(-speed, rb.velocity.y);
            // rb.velocity += Vector2.left * 1;
            //transform.Translate(Vector2.left * 0.1f);
        }
            

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            gameOverPanel.SetActive(true);
        }
        if (collision.tag == "Bullet")
        {

            Destroy(gameObject);
        }
    }

}
