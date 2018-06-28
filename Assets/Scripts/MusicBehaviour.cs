using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBehaviour : MonoBehaviour {

    [Header("Background Music")]
    public AudioSource musicController;

    /*[Header("Player's GameOver sound effect")]
    public AudioClip aClip; */

    public void Start()
    {
        musicController.Play();
    }
    public void Update()
    {
        if (GameControllerBehaviour.gameOver)
        {
            musicController.Stop();
        }
    }
}
