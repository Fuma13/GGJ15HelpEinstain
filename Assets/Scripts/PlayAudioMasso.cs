using UnityEngine;
using System.Collections;

public class PlayAudioMasso : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (transform.position.x > 0)
            audio.pan = 1;
        else
            audio.pan = -1;
	}
	
	// Update is called once per frame
	void Update () {

        if(transform.position.y < 0 && !audio.isPlaying)
        {
            audio.Play();
        }
	
	}
}
