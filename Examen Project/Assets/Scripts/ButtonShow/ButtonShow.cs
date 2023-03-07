using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShow : MonoBehaviour
{
    public GameObject showObj;

    public bool destroyAfter;
    public float destroyAfterTime;

    /// <summary>
    /// On collision show show obj on position
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            showObj.SetActive(true);
            if (destroyAfter)
                Invoke(nameof(DestroyAfter), destroyAfterTime);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            showObj.SetActive(false);
        }
    }
    void DestroyAfter()
    {
        Destroy(gameObject);
    }
}
