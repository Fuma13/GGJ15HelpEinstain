using UnityEngine;
using System.Collections;

public class VolaGattini : MonoBehaviour {

   public float speed;
	public bool isRandom;
	
	void Start ()
	{
		/*if (isRandom == true) {
            transform.Rotate(0, 0, Random.Range(-45, 45));
		}*/

        transform.position = new Vector3( -14.5f,Random.Range(-5f,5f),2.0f);
        rigidbody2D.velocity = new Vector2(10, rigidbody2D.velocity.y);
        //transform.localScale = new Vector3(2.0f,1.0f,2.0f);
        Destroy( gameObject, 5 );

	}
}
