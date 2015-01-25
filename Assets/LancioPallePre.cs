using UnityEngine;
using System.Collections;

public class LancioPallePre : MonoBehaviour {


    public GameObject palla1, palla2;
    public Animator galileo;
    public DialogueController dc;
    private bool lanciato;
	// Use this for initialization
	void Start () {

        lanciato = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(!lanciato && dc.paused)
        {
            lanciato = true;
            Invoke("LanciaPalla1", 0);
            Invoke("LanciaPalla2", 0.5f);
        }

	}

    private void LanciaPalla1()
    {
        palla1.GetComponent<SpriteRenderer>().sortingOrder = 1;
        palla1.rigidbody2D.gravityScale = 1;
        galileo.SetTrigger("Restart");
    }

    private void LanciaPalla2()
    {
        palla2.GetComponent<SpriteRenderer>().sortingOrder = 1;
        palla2.rigidbody2D.gravityScale = 1;
        galileo.SetTrigger("Restart");
        dc.resume();
    }
}
