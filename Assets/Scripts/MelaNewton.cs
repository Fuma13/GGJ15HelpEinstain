using UnityEngine;
using System.Collections;

public class MelaNewton : MonoBehaviour {
    
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Limite" || coll.gameObject.tag == "Terreno" || coll.gameObject.layer == 8)
        {
            this.gameObject.layer = 8;
			Destroy(gameObject, 5);
        }
    }
}
