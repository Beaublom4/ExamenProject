using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int direction, pushDirection, pushDirectionBack;
    public Vector3 movement;
    public Animator anim;
    public bool canMove, isPushing;


    private void FixedUpdate()
    {
        if (canMove)
        {
            //reads WASD inputs.
            movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            moveCharacter(movement);
        }
            //changes the paramater direction of the animator.
            if (movement == new Vector3(0, 0, 0))
                direction = 0;
            else if (movement.x > 0)
                direction = 3;
            else if (movement.x < 0)
                direction = 4;
            if (movement.z > 0)
                direction = 2;
            else if (movement.z < 0)
                direction = 1;

            if (isPushing)
            {
                if (movement != new Vector3(0, 0, 0))
                    if (direction != pushDirection && direction != pushDirectionBack)
                    {
                        GetComponentInChildren<PushPuzzel>().LeavePuzzel();
                    }
            }

            anim.SetInteger("direction", direction);
    }
    void moveCharacter(Vector3 direction)
    {
        //moves the player in the right direction times speed.
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }


}
