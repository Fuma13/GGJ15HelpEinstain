using UnityEngine;
using System.Collections;

public class ContattoPalle : MonoBehaviour {

    private DialogueController dc;
    public GameObject obj1;
    public GameObject obj2;

    void Start()
    {
        dc = GetComponent<DialogueController>();
    }

    void Update()
    {
        if (dc.paused)
        {
            obj1.rigidbody2D.gravityScale = 1;
            obj2.rigidbody2D.gravityScale = 1;
        }
    }

	void OnCollisionEnter2D(Collision2D coll)
    {
        Invoke("resume", 1);
    }

    void resume()
    {
        dc.resume();
    }
}
