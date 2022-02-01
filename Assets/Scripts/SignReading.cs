/*****************************************
 * Edited by: Ryan Scheppler
 * Last Edited: 1/27/2021
 * Description: Add to an object with a trigger collider to detect when to turn on a different text object or not.
 * *************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignReading : MonoBehaviour
{
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Text.SetActive(false);
        }
    }
}
