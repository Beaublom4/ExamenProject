using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitching : MonoBehaviour
{
    public GameObject newcamPos,  newPlayerpos;
    private GameObject cam;

    private void Start()
    {
        //gets the camera and assigns it to the gameobject
        cam = Camera.main.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //calles SwitchCam when player collides with this object and sets player position to new position.
        if(collision.transform.tag == "Player")
        {
            cam.GetComponent<CameraScript>().SwitchCam(newcamPos.transform);
            collision.transform.position = newPlayerpos.transform.position;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, transform.localScale);

        if (newPlayerpos != null)
        {
            Gizmos.DrawSphere(newPlayerpos.transform.position, 0.5f);
        }

        if (newcamPos != null)
        {
            Gizmos.color = Color.grey;
            Gizmos.DrawSphere(newcamPos.transform.position, 0.5f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, (transform.localScale -(Vector3.one / 10)));

        if (newPlayerpos != null)
        {
            Gizmos.DrawSphere(newPlayerpos.transform.position, 0.3f);
        }

        if (newcamPos != null)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawSphere(newcamPos.transform.position, 0.3f);
        }
    }
}
