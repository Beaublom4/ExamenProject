using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPuzzel : MonoBehaviour
{
    public int pushDir, pushDirBack;
    public void SelectedPuzzel(Transform player)
    {
        transform.SetParent(player);
        player.GetComponent<PlayerMovement>().pushDirection = pushDir;
        player.GetComponent<PlayerMovement>().pushDirectionBack = pushDirBack;
    }
    public void LeavePuzzel()
    {
        transform.SetParent(null);
    }
}
