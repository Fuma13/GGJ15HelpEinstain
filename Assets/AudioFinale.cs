using UnityEngine;
using System.Collections;

public class AudioFinale : MonoBehaviour {

    public AudioClip loop;
    private bool partito;
	// Use this for initialization
	void Start () {
        partito = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(audio.time);
        if(!partito && audio.time > 11.35f)
        {
            partito = true;
            audio.clip = loop;
            audio.loop = true;
            audio.Play();
        }
	
	}
}
