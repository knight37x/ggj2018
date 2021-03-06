﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynapseSelection : MonoBehaviour {

    public Type syn = typeof(DefaultSynapse);
    public int price = 20;

    public void setDefaultSyn()
    {
        syn = typeof(DefaultSynapse);
        price = 20;
    }
    public void setFastSyn()
    {
        syn = typeof(FastSynapse);
        price = 45;
    }
    public void setTriangleSyn()
    {
        syn = typeof(TriangleSynapse);
        price = 5;
    }
    public void setCircleSyn()
    {
        syn = typeof(CircleSynapse);
        price = 5;
    }
    public void setSquareSyn()
    {
        syn = typeof(SqareSynapse);
        price = 5;
    }

}
