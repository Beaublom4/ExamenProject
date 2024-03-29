using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform startPos;

    private void Start()
    {
        SwitchCam(startPos);
    }

    public void SwitchCam(Transform newParent)
    {
        //takes camera obj and switches it to new lvl.
        this.transform.SetParent(newParent);
        this.transform.position = this.transform.parent.position;
    }
}
