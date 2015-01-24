using UnityEngine;
using System.Collections;

public class GiocatoreGalileo : MonoBehaviour {

    public float xPos = -4f;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(xPos, transform.position.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(-transform.localPosition.x, transform.position.y, 0);
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ostacolo")
            Debug.Log("HIT!!");
    }
}
