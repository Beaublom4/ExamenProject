using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;

    [Tooltip("display above player on player prefab")]
    public Transform spawnPos;
    private GameObject currentObj;

    public float popUpTime;

    IEnumerator routine;

    private void Awake()
    {
        Instance = this;
    }
    public void NewRoutine(GameObject prefab)
    {
        if(currentObj != null)
            Destroy(currentObj);
        if (routine != null)
            StopCoroutine(routine);
        routine = Routine();
        StartCoroutine(routine);
    }
    IEnumerator Routine()
    {
        currentObj = Instantiate(currentObj, spawnPos);
        yield return new WaitForSeconds(popUpTime);
        Destroy(currentObj);
    }
}
