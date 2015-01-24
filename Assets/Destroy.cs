using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    void OnBecameInvisible()
    {
        if(Application.isPlaying)
            Destroy(gameObject);
    }
}
