/*****************************************
 * Edited by: Ryan Scheppler
 * Last Edited: 1/27/2021
 * Description: Add to things that need to disappear after a set time. 
 * *************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtTime : MonoBehaviour
{
    //time to wait before destroying
    public float DeathTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DeathTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
