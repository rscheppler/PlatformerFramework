/*****************************************
 * Edited by: Ryan Scheppler
 * Last Edited: 1/27/2021
 * Description: Add to any one way platforms you want the player to be able to go down through, note that you may need another collider the player doesn't collide with to stop other objects and things.
 * *************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private PlatformEffector2D myEffector;
    public float waitTime;

   // bool downPressedPrevious;

    // Start is called before the first frame update
    void Start()
    {
        myEffector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical") >= 0)
        {
            waitTime = 0.5f;
           // downPressedPrevious = false;
        }

        if(Input.GetAxisRaw("Vertical") < 0)
        {
            if (waitTime < 0)
            {
                myEffector.rotationalOffset = 180f;
                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if(Input.GetAxisRaw("Jump") > 0)
        {
            myEffector.rotationalOffset = 0;
        }


    }
}
