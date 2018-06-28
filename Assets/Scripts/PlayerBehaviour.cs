using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*Notes:
 * 22/06/2018 - Input.GetMouseButtonDown(0) will work at unity but not in Android deploy, it's necessary to use GetTouch(0) (check Update)
 */

public class PlayerBehaviour : MonoBehaviour {

    private Animator playerAnim;
    private Rigidbody2D rb;
    private float speed;
    private Vector2 jumpForce;
    private bool onGround;
    private AudioSource audioEffect;
    private AudioSource musicControllerSource;

    [Header("Music Controller")]
    public GameObject musicController;

    

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    // Initialising variables
    void Start () {
        this.playerAnim = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
        this.audioEffect = GetComponent<AudioSource>();
        musicControllerSource = this.musicController.GetComponent<AudioSource>();
        jumpForce = new Vector2(0, 250);
        onGround = true;
	}

    // Update is called once per frame
    void Update () {

        playerAnim.SetBool("start", GameControllerBehaviour.startGame); // Game starts once the player touches the screen
        CheckJump();
        GettingHarder(GameControllerBehaviour.score);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        const string TERRAIN = "Terrain";
        const string OBSTACLE = "Obstacle";
        const string POINT = "Point";

        switch (collision.tag)
        {
            case TERRAIN:
                onGround = true;
                playerAnim.SetBool("jump", !onGround);
                break;

            case OBSTACLE:
                GameControllerBehaviour.gameOver = true;
                playerAnim.SetBool("dead", GameControllerBehaviour.gameOver);
                musicControllerSource.Stop();
                break;

            case POINT:
                GameControllerBehaviour.score += 5; // 5 * 2, to analize
                break;
        }
    }

    private void CheckJump()
    {
        /* Android */

        if ((onGround && !GameControllerBehaviour.gameOver) && Input.GetTouch(0).phase == TouchPhase.Began) //Gets the touch in Android
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) //Gets if player isn't touching the UI
            {
                Jump();
            }
        }
        

        /* Unity 
         
         if ((onGround && !GameControllerBehaviour.gameOver) && Input.GetMouseButtonDown(0)) //Gets the touch in Unity
        {
            if (!EventSystem.current.IsPointerOverGameObject()) //Gets if player isn't touching the UI
            {
                Jump();
            }

        }
        */

    }

    private void Jump()
    {
        onGround = false;
        playerAnim.SetBool("jump", !onGround);
        rb.AddForce(jumpForce);
        audioEffect.Play();
    }

    private void GettingHarder(int score)
    {
        if (score > 50 && score < 150)
        {
            this.rb.gravityScale = 1.15f;
        }
        else if (score > 151 && score < 300)
        {
            this.rb.gravityScale = 1.3f;
            this.jumpForce = new Vector2(0, 240);
        }
        else if (score > 400)
        {
            this.rb.gravityScale = 1.5f;
        }
    }

}
