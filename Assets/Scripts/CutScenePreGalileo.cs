using UnityEngine;
using System.Collections;

public class CutScenePreGalileo : MonoBehaviour {

    bool pausa;
    Vector3 posizioneIniziale;
    public Transform primoGoal;
    public GameObject moglie;
    private float deltaMovimento, tempoMovimento;
    private enum PreGalileoState { SI_AVVICINA };
    private PreGalileoState stato;
    private DialogueController dc;


	// Use this for initialization
	void Start () {
        pausa = false;
        deltaMovimento = 0.01f;
        tempoMovimento = 0;
        posizioneIniziale = moglie.transform.position;
        dc = GetComponent<DialogueController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!pausa)
        {
            tempoMovimento += deltaMovimento;
            moglie.transform.position = Vector3.Lerp(posizioneIniziale, primoGoal.position, tempoMovimento);
            if (tempoMovimento >= 1)
            {
                //Parla!
                dc.resume();
                pausa = true;

            }
        }
	}
}
