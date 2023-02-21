using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject swordHitbox, swordPos;
    private GameObject swordHit;
    private Vector3 newPos;
    private Vector3 swordRotation;

    // Update is called once per frame
    void Update()
    {
        //check en set rotation of the sword attack.
        int dir = GetComponent<PlayerMovement>().direction;
        if (dir == 1)
        {
            newPos = new Vector3(0, 0, -0.5f);
            swordRotation = new Vector3(-90,0,0);
        }
        else if (dir == 2)
        {
            newPos = new Vector3(0, 0, 0.5f);
            swordRotation = new Vector3(90, 0, 0);
        }
        else if (dir == 3)
        {
            newPos = new Vector3(.75f, 0, 0);
            swordRotation = new Vector3(-90, 0, -90);
        }
        else if (dir == 4)
        {
            newPos = new Vector3(-.75f, 0, 0);
            swordRotation = new Vector3(90, 0, 90);
        }

        swordPos.transform.localPosition = newPos;

        //call swordAttack if you use the J button.
        if (Input.GetButtonDown("Sword"))
        {
            SwordAttack();
        }
    }

    private void SwordAttack()
    {
        //spawn the swordHitBox.
        swordHit = Instantiate(swordHitbox, swordPos.transform.position, Quaternion.Euler(swordRotation), swordPos.transform);
    }
}
