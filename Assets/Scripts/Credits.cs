using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

    public float limiteTop = 250f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y < limiteTop)
        transform.position = new Vector3(transform.position.x, transform.position.y+ 0.5f, transform.position.z);
        
	}

     

   
}
