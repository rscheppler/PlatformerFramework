/*****************************************
 * Edited by: Ryan Scheppler
 * Last Edited: 1/27/2021
 * Description: add to start button (or a level button or whatever) and set the onclick event to run the funciton in here.
 * *************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    //name of the scene to load on button click
    public string LevelToLoad = "BaseLevel";
    // add this function to the button onclick in the editor
    public void LevelLoad()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    public void ResetData()
    {
        GameManager.score = 0;
    }
}
