using UnityEngine;
using System.Collections;

public class TestaNewton : MonoBehaviour {

    private PersonaggioNewton padre;


    void Start()
    {
        padre = GetComponentInParent<PersonaggioNewton>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Ostacolo")
        {
            padre.Colpito();
            audio.Play();
        }
    }
}
