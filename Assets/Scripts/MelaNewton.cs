using UnityEngine;
using System.Collections;

public class MelaNewton : MonoBehaviour {
    
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Limite" || coll.gameObject.tag == "Terreno")
        {
            this.gameObject.layer = 8;
        }
    }
}
