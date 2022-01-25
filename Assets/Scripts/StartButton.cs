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
