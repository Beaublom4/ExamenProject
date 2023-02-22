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
}
