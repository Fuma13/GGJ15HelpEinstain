using UnityEngine;
using System.Collections;

public class CreditsGamePlay : MonoBehaviour {

   public  GameObject gattino;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Space))
            Instantiate(gattino);
	
	}
}
