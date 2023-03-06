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
        prevDirBack = pushDirBack;
    }
    public void SelectedPuzzel(Transform player)
    {
        transform.SetParent(player);
        player.GetComponent<PlayerMovement>().pushDirection = pushDir;
        player.GetComponent<PlayerMovement>().pushDirectionBack = pushDirBack;
    }
    public void LeavePuzzel()
    {
        GetComponentInParent<PlayerMovement>().isPushing = false;
        transform.SetParent(parent.transform);
    }

    public void ResetPushDirBack()
    {
        pushDirBack = prevDirBack;
        GetComponentInParent<PlayerMovement>().pushDirectionBack = pushDirBack;
    }
}
