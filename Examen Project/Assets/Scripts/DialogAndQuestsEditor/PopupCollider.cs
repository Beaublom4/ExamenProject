using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCollider : MonoBehaviour
{
    public GameObject display;
    public bool onStart;

    private void Start()
    {
        if (onStart)
        {
            PopupManager.Instance.NewRoutine(display);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PopupManager.Instance.NewRoutine(display);
            Destroy(gameObject);
        }
    }
}
