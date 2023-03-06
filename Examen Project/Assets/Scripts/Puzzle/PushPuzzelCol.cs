using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPuzzelCol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Puzzel")
        {
            other.transform.GetComponent<PushPuzzel>().LeavePuzzel();
            if (transform.tag == "PushPuzzelFinish")
                print("finish puzzel");
        }
    }
}
