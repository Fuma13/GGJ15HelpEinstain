using UnityEngine;
using System.Collections;

public class ProssimaScenaScript : MonoBehaviour {

    public string scena;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
            Application.LoadLevel(scena);
	}
}
