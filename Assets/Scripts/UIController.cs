using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {

    [Header("Idle")]
    public Text idleText;

    [Header("GameOver UI")]
    public GameObject gameOverBackground;

    [Header("Pause UI")]
    public GameObject pauseBackground;
    public GameObject pauseButton;

    [Header("Score")]
    public Text scoreText;

    public Text ScoreText
    {
        get
        {
            return scoreText;
        }

        set
        {
            scoreText = value;
        }
    }

    // Use this for initialization
    void Start () {
        idleText.gameObject.SetActive(true);
        SetGameOverUI();
        SetPauseUI(pauseBackground, pauseButton);
        this.ScoreText.text = "Score: " + GameControllerBehaviour.score.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        if (GameControllerBehaviour.startGame)
        {
            idleText.gameObject.SetActive(false);
        }
        if (GameControllerBehaviour.gameOver && !GameControllerBehaviour.pause)
        {
            Invoke("SetGameOverUI", 2.5f);
        }
        this.ScoreText.text = "Score: " + GameControllerBehaviour.score.ToString();
    }

    /*Methods that enables or disables elements of UI*/

    private void SetGameOverUI()
    {
        gameOverBackground.SetActive(GameControllerBehaviour.gameOver); 
    }

    public void SetPauseUI(GameObject pauseBackground, GameObject pauseButton)
    {
        pauseBackground.SetActive(GameControllerBehaviour.pause);
        pauseButton.SetActive(!GameControllerBehaviour.pause);
    }
}
