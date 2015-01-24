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
        if (!script.caduta)
        {
            transform.rotation = Quaternion.identity;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.position = new Vector3(-transform.localPosition.x, transform.position.y, 0);
            }
        }
        else
        {
            transform.Rotate(new Vector3(0f, 0f, 100f) * Time.deltaTime);
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ostacolo")
        {
            script.caduta = true;
            Debug.Log("HIT!!");
        }
    }
}
