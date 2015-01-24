using UnityEngine;
using System.Collections;

public class GiocatoreGalileo : MonoBehaviour {

    public float xPos = -4f;

    private RipetiTorreGalileo script;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(xPos, transform.position.y, 0);
        script = Camera.main.GetComponent<RipetiTorreGalileo>();
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
            script.caduta = true;
            Debug.Log("HIT!!");
    }
}
