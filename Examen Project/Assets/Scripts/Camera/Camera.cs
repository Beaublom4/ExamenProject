using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public void SwitchCam(Transform newParent)
    {
        this.transform.SetParent(newParent);
        this.transform.position = this.transform.parent.position;
    }
}
