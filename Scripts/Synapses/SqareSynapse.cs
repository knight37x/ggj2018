﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Filip
public class SqareSynapse : Synapse {

    private float transferspeed = 8;

    public Shape transferable = Shape.SQUARE;

    public override bool canTransfer(Shape data)
    {
        float duration = Weight / transferspeed;

        if (data == transferable && Time.time > lastTransmissionStart + duration)
        {
            return true;
        }
        Debug.Log("We have to wait: " + (Time.time - lastTransmissionStart - duration));
        return false;
    }

    public override float getProgress()
    {
        float duration = Weight / transferspeed;
        return (Time.time - lastTransmissionStart) / duration;
    }
}
