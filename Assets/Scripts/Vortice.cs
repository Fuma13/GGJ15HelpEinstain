using UnityEngine;
using System.Collections;

public class Vortice : MonoBehaviour {

    public float velocita = 3;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward, velocita);
	}
}
