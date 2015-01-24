using UnityEngine;
using System.Collections;

public class EinsteinSceneController : MonoBehaviour {

    public enum StatoScena{ MENU, MOGLIE_CAMMINA, MOGLIE_PARLA, VORTICE};
    public StatoScena statoScena;
    public GameObject moglie,vortice;
    public Sprite parla;
    public Transform dest;
    private Vector3 inizio;
    private float deltaMovimento, tempoMovimento;

	// Use this for initialization
	void Start () {

        statoScena = StatoScena.MENU;

        inizio = moglie.transform.position;
        deltaMovimento = 0.01f;
        tempoMovimento = 0;
        
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
                tempoMovimento += deltaMovimento;
                moglie.transform.position = Vector3.Lerp(inizio, dest.position, tempoMovimento);
                if (tempoMovimento >= 1)
                {
                    statoScena = StatoScena.MOGLIE_PARLA;
                    moglie.GetComponent<SpriteRenderer>().sprite = parla;
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
        //moglie.animation.Play();
        statoScena = StatoScena.MOGLIE_CAMMINA;
    }
}
