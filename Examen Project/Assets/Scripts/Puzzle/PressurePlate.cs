using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the base class for pressureplates where the plate varients can inherit from
/// </summary>

[RequireComponent(typeof(Collider))]
public class PressurePlate : MonoBehaviour
{
    [Tooltip("This is the tag used to check if an object should trigger the pressure plate")]
    [SerializeField] string weightTag = "Puzzel";
    [Tooltip("This is the time in seconds the weight object has to be on the plate before it triggers")]
    [SerializeField] float triggerDelay = 1;

    [HideInInspector] public bool checkPressureIsRunning = false;
    IEnumerator coroutine;

   public bool didTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != weightTag)
            return;

        coroutine = CheckPressure();
        StartCoroutine(coroutine);
        print($"pCheck start called");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == weightTag && checkPressureIsRunning)
        {
            StopCoroutine(coroutine);
            checkPressureIsRunning = false;
            print($"pCheck stop called");

        }
    }

    public virtual IEnumerator CheckPressure()
    {
        if (didTrigger == true)
            yield break;

        didTrigger = true;
        checkPressureIsRunning = true;


        print("Pressure check started");

        yield return new WaitForSeconds(triggerDelay);

        print("Pressure check delay has passed");

    }
}
