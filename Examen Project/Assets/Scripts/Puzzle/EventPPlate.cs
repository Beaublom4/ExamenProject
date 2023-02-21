using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPPlate : PressurePlate
{
    public override IEnumerator CheckPressure()
    {
        base.CheckPressure();
        print("wow cool event");

        //run some event like a quest update or chance in a room

        checkPressureIsRunning = false;
        yield return null;
    }
}
