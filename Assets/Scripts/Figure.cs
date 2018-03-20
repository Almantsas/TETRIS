﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour {


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            transform.position += new Vector3(-1, 0, 0);
            Debug.Log(transform.position);
        }
        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            transform.position += new Vector3(1, 0, 0);
            Debug.Log(transform.position);
        }
        if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            transform.position += new Vector3(0, -1, 0);
            Debug.Log(transform.position);
        }
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            transform.Rotate(0, 0, -90);
            Debug.Log(transform.position);
        }
    }
}