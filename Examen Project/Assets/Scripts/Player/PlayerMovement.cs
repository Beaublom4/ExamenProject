using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector3 movement;
    public Animator anim;
    public bool canMove;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            moveCharacter(movement);

            if (movement.x > 0)
                anim.SetInteger("direction", 3);
            else if (movement.x < 0)
                anim.SetInteger("direction", 4);
            if (movement.z > 0)
                anim.SetInteger("direction", 2);
            else if (movement.z < 0)
                anim.SetInteger("direction", 1);
        }
    }

    void moveCharacter(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }


}
