﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public Vector3 way;
    public float speed;

	// Use this for initialization
	void Start () {
        if (way.x >= way.y)
        {
            way = way / way.x;
        }
        else
        {
            
            way = way / way.y;
            
        }
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = transform.position + way * speed * Time.deltaTime;
	}
}
