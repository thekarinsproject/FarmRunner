using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBehaviour : MonoBehaviour {

    private UIController ui;

    [Header("Credits section")]
    public GameObject credits;

    public void Start()
    {
        this.ui = this.gameObject.GetComponent<UIController>();
        credits.SetActive(false);
    }
    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Open_DisposeCredits()
    {
        if (!credits.activeInHierarchy)
            credits.SetActive(true);
        else
            credits.SetActive(false);
    }

    public void Pause_Resume()
    {
        if (!GameControllerBehaviour.pause)
        {
            GameControllerBehaviour.pause = true;
            Time.timeScale = 0.0f;
        }
        else
        {
            GameControllerBehaviour.pause = false;
            Time.timeScale = 1.0f;
        }

        ui.SetPauseUI(ui.pauseBackground, ui.pauseButton); 
    }
}
