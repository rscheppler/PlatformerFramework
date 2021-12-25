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
    private float moveInputH;
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

    private AudioSource myAud;
    public AudioClip jumpNoise;

    //ladder things
    private bool isClimbing;
    public LayerMask whatIsLadder;
    public float ladderDist;
    private float moveInputV;
    private bool upPressed = false;




    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        myAud = GetComponent<AudioSource>();

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
            myAud.PlayOneShot(jumpNoise);
            myRb.drag = airDrag;
            myRb.velocity = (Vector2.up * jumpForce) + new Vector2(myRb.velocity.x, 0) ;
            jumpPressed = true;
        }
        else if (Input.GetAxisRaw("Jump") == 1 && jumpPressed == false && jumps > 0)
        {
            myAud.PlayOneShot(jumpNoise);
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



        moveInputH = Input.GetAxisRaw("Horizontal");
        if (isGrounded && !jumpPressed)
        {
            myRb.drag = groundDrag;
            myRb.AddForce(new Vector2(moveInputH * speed * Time.fixedDeltaTime, 0));
        }
        else
        {
            myRb.drag = airDrag;
            myRb.AddForce(new Vector2(moveInputH * speed * Time.fixedDeltaTime * airDrag/groundDrag, 0));
        }
        //check if we need to flip the player direction
        if (facingRight == false && moveInputH > 0)
            Flip();
        else if(facingRight == true && moveInputH < 0)
        {
            Flip();
        }

        //ladder things

        moveInputV = Input.GetAxisRaw("Vertical");
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, ladderDist, whatIsLadder);

        if( moveInputV <= 0 )
        {
            upPressed = false;
        }


        if(hitInfo.collider != null)
        {
            
            if(moveInputV > 0 && upPressed == false)
            {
                upPressed = true;
                isClimbing = true;
            }
            else
            {
                isClimbing = false;
            }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
   
    }
}
