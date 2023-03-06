using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPuzzelCol : MonoBehaviour
{
    private bool colided;
    private int prevBackDir;
    private void OnTriggerEnter(Collider other)
    {
        if (colided == false)
        {
            if (other.transform.tag == "Puzzel")
            {
                colided = true;
                other.transform.GetComponent<PushPuzzel>().LeavePuzzel();
                if (transform.tag == "PushPuzzelFinish")
                    print("finish puzzel");
                else
                {
                    other.transform.GetComponent<PushPuzzel>().pushDirBack = 0;
                }
            } 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Puzzel")
        {
            colided = false;
            if (transform.tag != "PushPuzzelFinish")
            {
                other.transform.GetComponent<PushPuzzel>().ResetPushDirBack();
            }
        }
    }
}
