using UnityEngine;
using System.Collections;

public class EinsteinSceneController : MonoBehaviour {

    public enum StatoScena{ MENU, MOGLIE_CAMMINA, MOGLIE_PARLA, VORTICE};
    public StatoScena statoScena;
    public GameObject moglie,vortice;

	// Use this for initialization
	void Start () {

        statoScena = StatoScena.MENU;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
            PlayPressed();
        if (Input.GetKeyDown(KeyCode.S))
            statoScena = StatoScena.VORTICE;

        switch(statoScena)
        {
            case StatoScena.MOGLIE_CAMMINA:
                if (moglie.animation["MoglieCammina"].time >= 1)
                {
                    statoScena = StatoScena.MOGLIE_PARLA;
                }
                break;
            case StatoScena.VORTICE:
                vortice.SetActive(true);
                moglie.transform.Rotate(Vector3.forward, 5);
                moglie.transform.localScale *= 0.99f;
                if (moglie.transform.localScale.x < 0.3f)
                {
                    vortice.SetActive(false);
                    moglie.SetActive(false);
                    //Application.LoadLevel("Vortice");
                }
                break;
        }


        
	
	}

    public void PlayPressed()
    {
        moglie.animation.Play();
        statoScena = StatoScena.MOGLIE_CAMMINA;
    }
}
