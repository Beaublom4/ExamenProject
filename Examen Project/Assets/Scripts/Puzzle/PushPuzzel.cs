using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPuzzel : MonoBehaviour
{
    public int pushDir, pushDirBack;
    public GameObject parent, frontPos, backPos;
    private int prevDirBack;
    public GameObject[] rewards;
    public bool complete = false;

    private void Start()
    {
        //assign prevDirback
        prevDirBack = pushDirBack;
    }
    public void SelectedPuzzel(Transform player)
    {
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(true);
        transform.GetChild(5).gameObject.SetActive(true);
        //sets player to right position and set player as parent and assigns direction.
        var dist1 = Vector3.Distance(player.position, frontPos.transform.position);
        var dist2 = Vector3.Distance(player.position, backPos.transform.position);
        if (dist1 <= dist2)
            player.position = frontPos.transform.position;
        else
            player.position = backPos.transform.position;
        transform.SetParent(player);
        player.GetComponent<PlayerMovement>().pushDirection = pushDir;
        player.GetComponent<PlayerMovement>().pushDirectionBack = pushDirBack;
    }
    public void LeavePuzzel()
    {
        //assigns gameobject parent as parent.
        SoundManager.Instance.StopSound();
        transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(false);
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
