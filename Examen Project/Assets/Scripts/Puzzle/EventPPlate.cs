using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPPlate : PressurePlate
{
    public GameObject secondPuzzlePart;
    public override IEnumerator CheckPressure()
    {
        base.CheckPressure();
        print("wow cool event");

        //run some event like a quest update or chance in a room
        secondPuzzlePart.SetActive(true);

        checkPressureIsRunning = false;
        yield return null;
    }
}
