using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCollider : MonoBehaviour
{
    public GameObject display;
    public string extraInfo;
    public bool onStart;

    private void Start()
    {
        if (onStart)
        {
            PopupManager.Instance.NewRoutine(display, extraInfo);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Display popup for time
            PopupManager.Instance.NewRoutine(display, extraInfo);
            Destroy(gameObject);
        }
    }
}
