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

    public AudioSource playerSource;
    public AudioClip pushClip;

    private void Start()
    {
        //Set timescale to 1.
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        if(canMove)
            movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //changes the paramater direction of the animator.
        if (movement == new Vector3(0, 0, 0))
        {
            direction = 0;
            if (playerSource.isPlaying)
                playerSource.Stop();
        }
        else if (movement.x > 0)
        {
            direction = 3;
            if(!playerSource.isPlaying)
                playerSource.Play();
        }
        else if (movement.x < 0)
        {
            direction = 4;
            if (!playerSource.isPlaying)
                playerSource.Play();
        }
        else if (movement.z > 0)
        {
            direction = 2;
            if (!playerSource.isPlaying)
                playerSource.Play();

        }
        else if (movement.z < 0)
        {
            direction = 1;
            if (!playerSource.isPlaying)
                playerSource.Play();
        }

        //checks if the player is pushing a puzzel object and makes him leave if the player moves away
        if (isPushing)
        {
            if (movement != new Vector3(0, 0, 0))
            {
                SoundManager.Instance.PlaySound(pushClip, 1f);
                if (direction != pushDirection && direction != pushDirectionBack)
                {
                    GetComponentInChildren<PushPuzzel>().LeavePuzzel();
                }
                else
                {
                    //SoundManager.Instance.StopSound();
                }
            }
        }

        if (canMove)
        {
            //reads movement (WASD) inputs.
            moveCharacter(movement);
        }

         anim.SetInteger("direction", direction);
    }
    void moveCharacter(Vector3 direction)
    {
        //moves the player in the right direction times speed and deltatime.
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }


}
