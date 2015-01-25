using UnityEngine;
using System.Collections;

public class EinsteinFinalScene : MonoBehaviour {

    public enum Stati { RICOMPARSA, PARLA_LEI, PARLA_LUI, PARLA_LEI2, IDEONA,LAMPADINA, NERO, NERO2, FINE };
    public Stati statoCorrente;
    public Transform dest;
    private Vector3 inizio;
    private float deltaMovimento, tempoMovimento;
    public GameObject moglie, einstein;
    private DialogueController dc;
    public Sprite einsteinParla, einsteinIdea,einsteinLampadina;
    public FadeController sfondoNero;
    public GameObject idonaText;

	// Use this for initialization
	void Start () {
        statoCorrente = Stati.RICOMPARSA;
        inizio = moglie.transform.position;
        deltaMovimento = 0.01f;
        tempoMovimento = 0;
        dc = GetComponent<DialogueController>();
	}
	
	// Update is called once per frame
	void Update () {
	
        switch(statoCorrente)
        {
            case Stati.RICOMPARSA:
                tempoMovimento += deltaMovimento;
                moglie.transform.position = Vector3.Lerp(inizio, dest.position, tempoMovimento);
                if (tempoMovimento >= 1)
                {
                    statoCorrente = Stati.PARLA_LEI;
                    dc.resume();
                }
                break;
            case Stati.PARLA_LEI:
                if (dc.paused)
                    statoCorrente = Stati.PARLA_LUI;
                break;
            case Stati.PARLA_LUI:
                einstein.GetComponent<SpriteRenderer>().sprite = einsteinParla;
                dc.resume();
                statoCorrente = Stati.PARLA_LEI2;
                break;
            case Stati.PARLA_LEI2:
                if (dc.paused)
                {
                    statoCorrente = Stati.IDEONA;
                    einstein.GetComponent<SpriteRenderer>().sprite = einsteinIdea;
                    dc.resume();
                }
                break;
            case Stati.IDEONA:
                if(dc.paused)
                {
                    statoCorrente = Stati.LAMPADINA;
                    einstein.GetComponent<SpriteRenderer>().sprite = einsteinLampadina;
                    dc.resume();
                }
                break;
            case Stati.LAMPADINA:
                if(dc.paused)
                {
                    statoCorrente = Stati.NERO;
                }
                break;
            case Stati.NERO:
                sfondoNero.FadeOff();
                statoCorrente = Stati.NERO2;
                break;
            case Stati.NERO2:
                if (!sfondoNero.enabled)
                {
                    einstein.GetComponent<SpriteRenderer>().sortingOrder = 3;
                    idonaText.SetActive(true);
                    dc.resume();
                    einstein.transform.localScale *= 1.5f;
                    statoCorrente = Stati.FINE;
                }
                break;
            case Stati.FINE:
                break;
        }
	}
}
