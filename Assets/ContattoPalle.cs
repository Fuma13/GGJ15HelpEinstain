using UnityEngine;
using System.Collections;

public class ContattoPalle : MonoBehaviour {


    private DialogueController dc;

    void Start()
    {

        dc = GetComponent<DialogueController>();
    }

	void OnCollisionEnter2D(Collision2D coll)
    {
        dc.resume();
    }
}
