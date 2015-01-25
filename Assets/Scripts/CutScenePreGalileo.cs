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

    public GameObject palla1, palla2;
    public Animator galileo;
    private bool lanciato;


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
        else
        {
            if (!lanciato && dc.paused)
            {
                lanciato = true;
                Invoke("LanciaPalla1", 0);
                Invoke("LanciaPalla2", 0.5f);
            }
        }
	}

    private void LanciaPalla1()
    {
        palla1.GetComponent<SpriteRenderer>().sortingOrder = 1;
        palla1.rigidbody2D.gravityScale = 1;
        galileo.SetTrigger("Restart");
    }

    private void LanciaPalla2()
    {
        palla2.GetComponent<SpriteRenderer>().sortingOrder = 1;
        palla2.rigidbody2D.gravityScale = 1;
        galileo.SetTrigger("Restart");
        dc.resume();
    }
}
