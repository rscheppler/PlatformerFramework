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
