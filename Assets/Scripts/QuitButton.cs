/*****************************************
 * Edited by: Ryan Scheppler
 * Last Edited: 1/27/2021
 * Description: add to quit button and set the onclick event to run the funciton in here.
 * *************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    //add this to a button to make it quit the game
    public void QuitNow()
    {
        Application.Quit();
    }
}
