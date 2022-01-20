using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public float speed;
    public bool movingRight = false;

    public Transform detection;

    private Rigidbody2D myRB;

    public float groundRayDist = 2f;
    public float wallRayDist = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir;
    
        if (movingRight)
        {
            moveDir = Vector2.right;

        }
        else
        {
            moveDir = -Vector2.right;
        }

        myRB.AddForce(moveDir * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(detection.position, Vector2.down, groundRayDist);

        if(groundInfo.collider == false)
        {
            movingRight = !movingRight;
            transform.eulerAngles += new Vector3(0, 180, 0);
        }

        

        RaycastHit2D wallInfo = Physics2D.Raycast(detection.position, moveDir, wallRayDist);
        if (wallInfo.collider != false)
        {
            movingRight = !movingRight;
            transform.eulerAngles += new Vector3(0, 180, 0);
        }

    }
}
