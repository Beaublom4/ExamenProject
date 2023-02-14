using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitching : MonoBehaviour
{
    public GameObject camPos1, camPos2, cam;


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            if(cam.transform.parent == camPos1.transform)
            {
                cam.GetComponent<Camera>().SwitchCam(camPos2.transform);
            }
            else if(cam.transform.parent == camPos2.transform)
            {
                cam.GetComponent<Camera>().SwitchCam(camPos1.transform);
            }
        }
    }
}
