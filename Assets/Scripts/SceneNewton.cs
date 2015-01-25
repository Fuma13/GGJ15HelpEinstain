using UnityEngine;
using System.Collections;

public class SceneNewton : MonoBehaviour {

	Vector3 posizioneIniziale;
	public GameObject moglie;
	public GameObject newton;
	public GameObject uccello;
	public Transform primaPosizioneMoglie;
	public Transform secondaPosizioneMoglie;
	public GameObject mela;
    public Sprite moglieSullAlbero;

	private float deltaMovimento, tempoMovimento;
    private DialogueController dialogo;

	int numeroScena;

	// Use this for initialization
	void Start () {
	
		numeroScena = -1;
		posizioneIniziale = moglie.transform.position;
		tempoMovimento = 0;
		deltaMovimento = 0.01f;
        dialogo = Camera.main.GetComponent<DialogueController>();
	}
	
	// Update is called once per frame
	void Update () {

		switch ( numeroScena ){
		case -1:
                
			tempoMovimento+= deltaMovimento;
			moglie.transform.position = Vector3.Lerp( posizioneIniziale, primaPosizioneMoglie.position, tempoMovimento  );
			if ( tempoMovimento >= 1 ){
				numeroScena++;
				tempoMovimento = 0;
                //Invoke("Delay", 2);
                //mostro parlato descrizione scena
                dialogo.resume();
			}
			break;
        case 0:
            if (dialogo.paused)
                numeroScena++;
            break;
		case 1:
			uccello.GetComponent<VoloUccelliNewton>().enabled= true;
			uccello.GetComponent<SpriteRenderer>().sortingOrder=3;
			numeroScena++;
			Invoke("Delay",2);
			break;
        case 2:
            //if (dialogo.paused)
            //    numeroScena++;
			break;
		case 3:
			newton.GetComponent<PersonaggioNewton>().enabled= true;
			newton.GetComponent<Animator>().enabled= true;
			numeroScena++;
			Invoke("Delay",0.5f);
			break;
		case 4:
			break;
		case 5:
			
			mela.rigidbody2D.gravityScale=1;
			numeroScena++;
            //Invoke("Delay",0.5f);
                // mostro parlato oh cazzo
                dialogo.resume();
			break;
        case 6:
            if (dialogo.paused)
                numeroScena++;
			break;
		case 7:
			tempoMovimento+= deltaMovimento;
            moglie.GetComponent<SpriteRenderer>().color = new Color(moglie.GetComponent<SpriteRenderer>().color.r,
                                                                    moglie.GetComponent<SpriteRenderer>().color.g,
                                                                    moglie.GetComponent<SpriteRenderer>().color.b,
                                                                    Mathf.Lerp(1, 0, tempoMovimento));
			//moglie.transform.position = Vector3.Lerp( primaPosizioneMoglie.position, secondaPosizioneMoglie.position, tempoMovimento  );
			if ( tempoMovimento >= 1 ){
				numeroScena++;
                moglie.GetComponent<SpriteRenderer>().sprite = moglieSullAlbero;
                moglie.GetComponent<SpriteRenderer>().sortingOrder = 3;
                moglie.transform.position = secondaPosizioneMoglie.position;
                moglie.transform.localScale *= 0.7f;
                tempoMovimento = 0;
			}
			break;
            case 8:

            tempoMovimento += deltaMovimento;
            moglie.GetComponent<SpriteRenderer>().color = new Color(moglie.GetComponent<SpriteRenderer>().color.r,
                                                                moglie.GetComponent<SpriteRenderer>().color.g,
                                                                moglie.GetComponent<SpriteRenderer>().color.b,
                                                                Mathf.Lerp(0, 1, tempoMovimento));
            if (tempoMovimento >= 1)
            {
                numeroScena++;
                moglie.GetComponent<GiocatoreNewton>().abilitoSparo(true);
            }
            break;
            case 9 :
            if (newton.GetComponent<PersonaggioNewton>().vincita() == true)
            {
                numeroScena++;
            }
            break;

            case 10:
            moglie.GetComponent<GiocatoreNewton>().abilitoSparo(false);
                //mostro il parlato eureka e info per next
                dialogo.resume();
                numeroScena++;
            break;

            case 11:
            if (Input.GetKeyDown(KeyCode.Return))
                numeroScena++;
            break;

            case 12:
            moglie.GetComponent<Vortice>().enabled = true;
            //inserisco la funzione per cambiare scena
            break;
			
		}

	
	}

	void Delay()
	{
		numeroScena++;
		}

   
}
