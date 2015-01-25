using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public string scenaPlay;
    public string scenaCredit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void scenaGalileo(){
        Application.LoadLevel(scenaPlay);
    }

    public void scenaCredits(){
        Application.LoadLevel(scenaCredit); 
    }
}
