using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {

    private float speed = 3;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GameControllerBehaviour.startGame && !GameControllerBehaviour.gameOver)
        {
            Vector3 movement = new Vector3(speed, 0, 0);
            transform.position -= movement * Time.deltaTime;
            Destroy(this.gameObject, 5);
        }
        else
        {
            speed = 0;
            Destroy(this.gameObject);
        }
	}
}
