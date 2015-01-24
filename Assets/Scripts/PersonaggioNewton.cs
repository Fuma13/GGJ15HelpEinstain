using UnityEngine;
using System.Collections;

public class PersonaggioNewton : MonoBehaviour {

    private int direzione;
    public float velocita = 2;

	// Use this for initialization
	void Start () {
        direzione = 1;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector2(1, 0) * direzione * velocita * Time.deltaTime);
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Limite")
        {
            direzione *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
