/*****************************************
 * Edited by: Ryan Scheppler
 * Last Edited: 1/27/2021
 * Description: This is to let the player have a new checkpoint to respawn at, includes color to change which looks active, will set color to normal on all others.
 * *************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public Color ActiveColor = Color.green - new Color(0,0,0,0.5f);
    [HideInInspector]
    public Color InactiveColor = Color.cyan - new Color(0, 0, 0, 0.5f);
    [HideInInspector]
    public SpriteRenderer mySR;

    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        InactiveColor = mySR.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController PC = collision.gameObject.GetComponent<PlayerController>();
        if (PC !=null)
        {
            foreach (RespawnPoint RP in FindObjectsOfType<RespawnPoint>())
            {
                RP.mySR.color = RP.InactiveColor;
            }

            mySR.color = ActiveColor;
            PC.RespawnPoint = transform.position;
        }
    }
}
