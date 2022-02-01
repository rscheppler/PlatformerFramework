/*****************************************
 * Edited by: Ryan Scheppler
 * Last Edited: 1/27/2021
 * Description: Add this to objects thaht are picked up by the player for points and removed
 * *************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points = 10;

    public AudioClip PickUpNoise;

    public GameObject SpawnOnPickUp;

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
            GameManager.score += points;
            AudioSource PAud = collision.gameObject.GetComponent<AudioSource>();
            if(PAud != null)
            {
                PAud.PlayOneShot(PickUpNoise);
            }
            if(SpawnOnPickUp != null)
            {
                Instantiate(SpawnOnPickUp, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
