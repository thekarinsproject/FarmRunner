using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControllerBehaviour : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject spawn;
    public Spawner spawner;

    [HideInInspector]
    public static bool startGame;

    [HideInInspector]
    public static bool gameOver;

    [HideInInspector]
    public static bool pause;

    [HideInInspector]
    public static int score;

    [HideInInspector]
    public static int maxScore;


    private void Awake()
    {
        Instantiate(playerPrefab, spawn.transform.position, Quaternion.identity);
    }

    // Use this for initialization
    void Start () {
        Time.timeScale = 1.0f;
        startGame = false;
        gameOver = false;
        pause = false;
        score = 0;        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !startGame)
        {
            startGame = true;
        }
    }

}
