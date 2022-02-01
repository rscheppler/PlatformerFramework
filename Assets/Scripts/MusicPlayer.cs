/*****************************************
 * Edited by: Ryan Scheppler
 * Last Edited: 1/27/2021
 * Description: Only one will exist at a time, but allows customizing tracks to different levels, and if 2 levels have the same track does not reset the music.
 * *************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//make a struct that can be seen in the editor that links a level to a music track
[System.Serializable]
    public struct LevelTrack
    {
        public string LevelName;
        public AudioClip Music;
    };


public class MusicPlayer : MonoBehaviour
{
    //make sure only one exists
    public static MusicPlayer Instance;
    //array of tracks and the levels they go with
    public LevelTrack[] levelTracks;

    private AudioSource myAud;

    //check that there is only one MusicPlayer
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        myAud = GetComponent<AudioSource>();

        //play first track
        FindRightTrack();
        
    }

    private void OnLevelWasLoaded(int level)
    {
        
        FindRightTrack();
    }

    //This should check if the correct music is playing on any given level, and allow levels that share a track to keep playing rather than start and stop
    private void FindRightTrack()
    {
        
        foreach (LevelTrack LT in levelTracks)
        {
            if (SceneManager.GetActiveScene().name == LT.LevelName)
            {
                if (myAud.clip == null || myAud.clip.name != LT.Music.name)
                {
                    myAud.Stop();
                    myAud.clip = LT.Music;
                    myAud.Play();
                }
            }
        }
    }
}
