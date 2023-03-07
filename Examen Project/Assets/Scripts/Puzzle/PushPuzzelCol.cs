using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPuzzelCol : MonoBehaviour
{
    private bool colided;
    private int prevBackDir;
    private void OnTriggerEnter(Collider other)
    {
        //checks if the object that enter the trigger and leaves puzzel and completes puzzel.
        if (colided == false)
        {
            if (other.transform.tag == "Puzzel")
            {
                colided = true;
                other.transform.GetComponent<PushPuzzel>().LeavePuzzel();
                if (transform.tag == "PushPuzzelFinish")
                {
                    GameObject rew = other.transform.GetComponent<PushPuzzel>().reward;
                    rew.SetActive(!rew.activeSelf);
                    other.transform.GetComponent<PushPuzzel>().complete = true;
                }
                else
                {
                    other.transform.GetComponent<PushPuzzel>().pushDirBack = 0;
                }
            } 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // sets colided to false if object with puzzel tag leaves trigger
        if(other.transform.tag == "Puzzel")
        {
            colided = false;
            if (transform.tag != "PushPuzzelFinish")
            {
                //calls ResetPushDirBack if tag isnt PushPuzzelFinish
                other.transform.GetComponent<PushPuzzel>().ResetPushDirBack();
            }
        }
    }
}
