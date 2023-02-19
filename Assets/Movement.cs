using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool moveLeft = false, moveRight = false;
    public float horizontalMove;
    public float speed = 5f;
    private float jumpPower = 350f, shootPower = 5f;
    public Animator ani;
    private bool doubleJumpAllowed = false;
    private bool onTheGround = false;
    Vector3 localScale;
    float destroyTime = 2f;
    public bool facingRigt = true;
    public GameObject leftBullet, rightBullet;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    public grassMovementRL _grassMovementRL;
    public float countPoints = 0;
    public Text coinsText;
    private bool onGrassMoveR , onGrassMoveL;
    public GameObject winPanel;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
        localScale = transform.localScale;
        onGrassMoveR = true;
        onGrassMoveL = true;
    }
    public void PressLeftBut() // Press on left button
    {
      
        moveLeft = true;
    }

    public void NotPressLeftBut() // Not Press on left button
    {
        moveLeft = false;
    }
    public void PressRightBut() // Press on right button
    {
       
          moveRight = true;
    }

    public void NotPressRightBut() // // Not press on right button
    {
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        


        if (onTheGround) //Allowed double jump
            doubleJumpAllowed = true;

        if (onTheGround && Input.GetKeyDown("space"))
            Jump();
        else if(doubleJumpAllowed && Input.GetKeyDown("space"))
        {
            Jump();
            doubleJumpAllowed = false;
        }


    }

    private void PlayerMovement()
    {
        if ((moveLeft || Input.GetKey("left")) && onGrassMoveL)
        {
            facingRigt = false;
            horizontalMove = -speed;
            ani.SetTrigger("PlayerRun");
            if(localScale.x>0)   // Change direction of shot speed, image direction
            {
                localScale.x *= -1;
                shootPower = -shootPower;
                transform.localScale = localScale;
            }
                
        }
        else if ((moveRight || Input.GetKey("right")) && onGrassMoveR) 
        {
            facingRigt = true;
            horizontalMove = speed;
            ani.SetTrigger("PlayerRun");
            if(localScale.x < 0) // Change direction of shot speed, image direction
            {
                shootPower = -shootPower;
                localScale.x *= -1;
                transform.localScale = localScale;
            }
                
        }

        else // no movement
        {
            horizontalMove = 0;
            ani.SetTrigger("PlayerStand");
        }
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y); // player's movement
        coinsText.text = "coins: " + countPoints;

    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpPower);


    }

    public void PressJumpBut()
    {
        if (onTheGround)
            Jump();
        else if (doubleJumpAllowed)
        {
            Jump();
            doubleJumpAllowed = false;
        }
    }

    public void PressShootBut()
    {
        bulletPos = transform.position;
        if (facingRigt)
        {
            Instantiate(rightBullet, bulletPos, Quaternion.identity);
        }
        else
        {
            Instantiate(leftBullet, bulletPos, Quaternion.identity);
        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
       if( collision.gameObject.CompareTag("Ground"))
            onTheGround = true;
        if (collision.gameObject.CompareTag("GroundMove"))
        {
            onTheGround = true;
            if (facingRigt)
            {
                //onGrassMoveR = true;
                onGrassMoveL = false;
                print("r" + onGrassMoveR);
                print("l" + onGrassMoveL);
            }
            else
            {
               // onGrassMoveL = true;
                onGrassMoveR = false;
                print("r1" + onGrassMoveR);
                print("l1" + onGrassMoveL);
            }
           
        }
           




    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            onTheGround = false;

        if (collision.gameObject.CompareTag("GroundMove"))
        {
            onTheGround = false;
            onGrassMoveR = true;
            onGrassMoveL = true;
        }
           
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
           
            countPoints += 10;
        }

        if (collision.tag == "door")
        {

            winPanel.SetActive(true);
        }
    }


}
