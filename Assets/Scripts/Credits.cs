using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y  < 250f)
        transform.position = new Vector3(transform.position.x, transform.position.y+ 0.5f, transform.position.z);
        
	}

     

   
}
