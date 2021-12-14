/*****************************************
 * Edited by: Ryan Scheppler
 * Last Edited: 12/8/2021
 * Description: This should be added to the player in a simple 2D platformer 
 * *************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    //speed and movement variables
    public float speed;
    private float moveInput;
    //grab this to adjust physics
    private Rigidbody2D myRb;

    //used for checking what direction to be flipped
    private bool facingRight = true;

    //things for ground checking
    private bool isGrounded = false;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //jump things
    public int jumpTotal = 1;
    private int jumps;
    public float jumpForce;
    private bool jumpPressed = true;

    public float groundDrag = 5;
    public float airDrag = 1;


    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();

        jumps = jumpTotal;
    }

    //Update is called once per frame
    private void Update()
    {
        if(isGrounded == true)
        {
            jumps = jumpTotal;
        }
        //check if jump can be triggered
        if (Input.GetAxisRaw("Jump") == 1 && jumpPressed == false && isGrounded == true)
        {
            myRb.drag = airDrag;
            myRb.velocity = (Vector2.up * jumpForce) + new Vector2(myRb.velocity.x, 0) ;
            jumpPressed = true;
        }
        else if (Input.GetAxisRaw("Jump") == 1 && jumpPressed == false && jumps > 0)
        {
            myRb.drag = airDrag;
            myRb.velocity = ( Vector2.up * jumpForce) + new Vector2(myRb.velocity.x, 0);
            jumpPressed = true;
            jumps--;
        }
        else if(Input.GetAxisRaw("Jump") == 0)
        {
            jumpPressed = false;
        }
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        //check for ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);



        moveInput = Input.GetAxisRaw("Horizontal");
        if (isGrounded && !jumpPressed)
        {
            myRb.drag = groundDrag;
            myRb.AddForce(new Vector2(moveInput * speed * Time.fixedDeltaTime, 0));
        }
        else
        {
            myRb.drag = airDrag;
            myRb.AddForce(new Vector2(moveInput * speed * Time.fixedDeltaTime * airDrag/groundDrag, 0));
        }
        //check if we need to flip the player direction
        if (facingRight == false && moveInput > 0)
            Flip();
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }


       

    }
    //flip the player so sprite faces the other way
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
