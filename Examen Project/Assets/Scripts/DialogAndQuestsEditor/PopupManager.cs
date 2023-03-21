using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;

    [Tooltip("display above player on player prefab")]
    public Transform spawnPos;
    private GameObject currentObj;
    public TMP_Text extraPopUpText;
    public GameObject extraPopUpObj;

    public float popUpTime;

    IEnumerator routine;

    private void Awake()
    {
        Instance = this;
    }
    public void NewRoutine(GameObject prefab, string text)
    {
        if(currentObj != null)
            Destroy(currentObj);
        if (routine != null)
            StopCoroutine(routine);
        routine = Routine(prefab, text);
        StartCoroutine(routine);
    }
    IEnumerator Routine(GameObject prefab, string text)
    {
        currentObj = Instantiate(prefab, spawnPos);
        if (!string.IsNullOrEmpty(text))
        {
            extraPopUpText.text = text;
            extraPopUpObj.SetActive(true);
        }
        yield return new WaitForSeconds(popUpTime);
        Destroy(currentObj);
        extraPopUpObj.SetActive(false);
    }
}
