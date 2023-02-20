using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Vector3 movement;
    public Animator anim;
    public bool canMove;


    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            //reads WASD inputs.
            movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            moveCharacter(movement);
        }
    }

    private void FixedUpdate()
    {
        //changes the paramater direction of the animator.
        if (movement == new Vector3(0, 0, 0))
            anim.SetInteger("direction", 0);
        else if (movement.x > 0)
            anim.SetInteger("direction", 3);
        else if (movement.x < 0)
            anim.SetInteger("direction", 4);
        if (movement.z > 0)
            anim.SetInteger("direction", 2);
        else if (movement.z < 0)
            anim.SetInteger("direction", 1);
    }
    void moveCharacter(Vector3 direction)
    {
        //moves the player in the right direction times speed.
        transform.Translate(direction * speed * Time.deltaTime);
    }


}
