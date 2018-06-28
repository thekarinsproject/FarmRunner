using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Repeats the background*/

public class RepeatBackground : MonoBehaviour {

    //VARIABLES
    [Tooltip ("Velocidad de movimiento del fondo")]
    public float scrollSpeed;

    //background's width size.
    public const float scrollWidth = 6;

    //the background will be moving in fixed time intervals
    private void FixedUpdate()
    {
        if (GameControllerBehaviour.startGame && !GameControllerBehaviour.gameOver)
        {
            //Actual position
            Vector3 pos = this.transform.position;

            //Lateral movement
            pos.x -= this.scrollSpeed * Time.deltaTime * 2;

            //if background is not in view is destroyed.

            if (this.transform.position.x < -scrollWidth)
            {
                Offscreen(ref pos);
            }

            //if background is not destroyed, his position is recalculated.

            this.transform.position = pos;
        }
    }

    // virtual allows to modify implementations in child classes
    // the background position is modified by reference value
    //Method Offscreen it's called when background has surpassed the view
    protected virtual void Offscreen(ref Vector3 pos) {
        pos.x += 2 * scrollWidth;
    }
}
