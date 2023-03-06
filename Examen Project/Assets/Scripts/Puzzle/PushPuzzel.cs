using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPuzzel : MonoBehaviour
{
    public int pushDir, pushDirBack;
    public GameObject parent;
    private int prevDirBack;

    private void Start()
    {
        //assign prevDirback
        prevDirBack = pushDirBack;
    }
    public void SelectedPuzzel(Transform player)
    {
        //sets player as parent and assigns direction.
        transform.SetParent(player);
        player.GetComponent<PlayerMovement>().pushDirection = pushDir;
        player.GetComponent<PlayerMovement>().pushDirectionBack = pushDirBack;
    }
    public void LeavePuzzel()
    {
        //assigns gameobject parent as parent.
        GetComponentInParent<PlayerMovement>().isPushing = false;
        transform.SetParent(parent.transform);
    }

    public void ResetPushDirBack()
    {
        //resets pushDirBack.
        pushDirBack = prevDirBack;
        GetComponentInParent<PlayerMovement>().pushDirectionBack = pushDirBack;
    }
}
