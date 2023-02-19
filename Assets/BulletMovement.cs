using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float velX = 60f;
    float velY = 0f;
    Rigidbody2D rb;
    float destroyTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, destroyTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            Destroy(gameObject);
    }
}
