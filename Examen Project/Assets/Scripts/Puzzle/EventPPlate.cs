using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPPlate : PressurePlate
{
    public GameObject[] rewards;
    public override IEnumerator CheckPressure()
    {
        base.CheckPressure();

        foreach (var reward in rewards)
        {
            reward.SetActive(!reward.activeSelf);
        }

        checkPressureIsRunning = false;
        yield return null;
    }
}
