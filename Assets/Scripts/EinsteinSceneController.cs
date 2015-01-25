using UnityEngine;
using System.Collections;

public class EinsteinSceneController : MonoBehaviour {

    public enum StatoScena{ MENU, MOGLIE_CAMMINA, MOGLIE_PARLA,FINE_PARLA, VORTICE};
    public StatoScena statoScena;
    public GameObject moglie,vortice;
    public Sprite parla;
    public Transform dest;
    private Vector3 inizio;
    private float deltaMovimento, tempoMovimento;
    private DialogueController dc;

	// Use this for initialization
	void Start () {

        statoScena = StatoScena.MOGLIE_CAMMINA;

        inizio = moglie.transform.position;
        deltaMovimento = 0.01f;
        tempoMovimento = 0;
        dc = GetComponent<DialogueController>();
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
                    statoScena = StatoScena.FINE_PARLA;
                    moglie.GetComponent<SpriteRenderer>().sprite = parla;
                    dc.resume();
                }
                break;
            case StatoScena.FINE_PARLA:
                if(dc.paused)
                {
                    statoScena = StatoScena.VORTICE;
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
                    dc.resume();
                }
                break;
        }
	}

    public void PlayPressed()
    {
        statoScena = StatoScena.MOGLIE_CAMMINA;
    }
}
