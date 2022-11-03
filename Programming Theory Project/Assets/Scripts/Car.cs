using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Unit
{
    void Update()
    {
        GoForward(1);

        if (AvoidOverRange())
        {
            Destroy(gameObject);
        }
    }

    public override void TurnLeftRight(float input)
    {
        return;
    }
}
