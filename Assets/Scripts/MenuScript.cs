using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void scenaGalileo(){
        Application.LoadLevel (1);
    }

    public void scenaCredits(){
        Application.LoadLevel (9); 
    }
}
