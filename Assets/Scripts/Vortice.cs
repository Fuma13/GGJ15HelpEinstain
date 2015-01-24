﻿using UnityEngine;
using System.Collections;

public class Vortice : MonoBehaviour {

    public float velocita = 3;
    public bool scale = false;

	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward, velocita);
        if (scale == true)
            transform.localScale *= 0.99f;
	}

    
}
