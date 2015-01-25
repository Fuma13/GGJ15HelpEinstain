using UnityEngine;
using System.Collections;

public class RipetiTorreGalileo : MonoBehaviour {

    public GameObject torrePrefab;
    private GameObject torre1, torre2;
    private float torreHeight;
    private int tilesAttraversati = 0;
    private int tilesScesi = 0;
    public int tilesDaScendere;
    public int tilesPerLaCima;
    //COMMANDO PATTERN!
    [HideInInspector]
    public bool caduta = false;
    //COMMANDO PATTERN!
    [HideInInspector]
    public bool finoInFondo = false;
    private GameObject torreFondo = null;
    public bool inCima = false;
    private SpawnerGalileo_B spawner;
    private GameObject cima = null;
    //COMMANDO PATTERN!
    [HideInInspector]
    public bool stop = false;
    public GameObject giocatore;
    private bool primoFadeOut = false;
    private DialogueController dc;

	// Use this for initialization
	void Start () {
        torreHeight = torrePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        torre1 = (GameObject)Instantiate(torrePrefab, Vector3.zero, Quaternion.identity);
        torre1.GetComponent<TorreBehaviourGalileo>().posizione = 0;
        torre2 = (GameObject)Instantiate(torrePrefab, new Vector3(0, torre1.transform.position.y + (torreHeight * torrePrefab.transform.localScale.y), 0), Quaternion.identity);
        torre2.GetComponent<TorreBehaviourGalileo>().posizione = 1;
        dc = Camera.main.GetComponent<DialogueController>();
        spawner = Camera.main.GetComponent<SpawnerGalileo_B>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(finoInFondo);
        //Debug.Log("Tiles attraversati: "+tilesAttraversati);
        /*if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (caduta) caduta = false;
            else caduta = true;
        }
        */
        /*if (torreFondo != null && !inFondo)
        {
            if (torreFondo.transform.localPosition.y + 2 > Camera.main.orthographicSize)
            {
                inFondo = true;
                torreFondo = null;
                caduta = false;
                Invoke("restart", 1);
            }
        }*/

        if (finoInFondo && torreFondo!=null)
        {
            if (torreFondo.transform.localPosition.y + 2 > Camera.main.orthographicSize)
            {
                finoInFondo = false;
                torreFondo = null;
                caduta = false;
                Invoke("restart", 1);
            }
        }

        if (tilesAttraversati >= tilesPerLaCima - 1 && !inCima)
        {
            inCima = true;
            spawner.PLEASE_STOP();
            if (torre1.transform.position.y > torre2.transform.position.y) cima = torre1;
            else cima = torre2;
        }
        /*else
        {
            inCima = false;
            cima = null;
        }*/

        if ((giocatore.renderer as SpriteRenderer).color.a == 0)
        {
            stop = false;
        }

        if (primoFadeOut && cima.transform.position.y<-7 && !stop)
        {
            stop = true;
            //giocatore.transform.localPosition = new Vector3(-1.9f, 1.28f, 0);
            giocatore.transform.localPosition = new Vector3(-1.9f, 2.45f, 0);
            giocatore.GetComponent<GiocatoreGalileo>().startFadeIn();
        }

        if (stop && primoFadeOut && (giocatore.renderer as SpriteRenderer).color.a == 1)
        {
            Invoke("resume", 1);
        }

        //PHONG PATTERN
        if (inCima && cima!=null && !stop && !primoFadeOut)
        {
            if (cima.transform.localPosition.y < -1.2763)
            {
                primoFadeOut = true;
                cima.transform.position = new Vector3(cima.transform.localPosition.x, -1.27f, cima.transform.localPosition.z);
                stop = true;
                giocatore.GetComponent<GiocatoreGalileo>().startFadeOut();
            }
            /*if (cima.transform.localPosition.y<-2.21)
            {
                primoFadeOut = true;
                cima.transform.position=new Vector3(cima.transform.localPosition.x, -2.18f, cima.transform.localPosition.z);
                stop = true;
                giocatore.GetComponent<GiocatoreGalileo>().startFadeOut();
            }*/
        }

        /*if (torre1.transform.position.y > torre2.transform.position.y) torreHeight = torre1.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        else torreHeight = torre2.GetComponent<SpriteRenderer>().sprite.bounds.size.y;*/

        if (!finoInFondo && !inCima)
        {
            if (!caduta)
            {
                if (torre1.transform.position.y + ((torreHeight * torrePrefab.transform.localScale.y) / 2) < -Camera.main.orthographicSize)
                {
                    tilesAttraversati++;
                    torre1.transform.position = new Vector3(0, torre2.transform.position.y + (torreHeight * torrePrefab.transform.localScale.y));
                    torre1.GetComponent<TorreBehaviourGalileo>().posizione += 2;
                }
                if (torre2.transform.position.y + ((torreHeight * torrePrefab.transform.localScale.y) / 2) < -Camera.main.orthographicSize)
                {
                    tilesAttraversati++;
                    torre2.transform.position = new Vector3(0, torre1.transform.position.y + (torreHeight * torrePrefab.transform.localScale.y));
                    torre2.GetComponent<TorreBehaviourGalileo>().posizione += 2;
                }
            }
            else
            {
                if (torre1.transform.position.y - ((torreHeight * torrePrefab.transform.localScale.y) / 2) > Camera.main.orthographicSize)
                {
                    if (torre1.GetComponent<TorreBehaviourGalileo>().posizione - 2 >= 0)
                    {

                        tilesAttraversati--;
                        tilesScesi++;
                        torre1.transform.position = new Vector3(0, torre2.transform.position.y - (torreHeight * torrePrefab.transform.localScale.y));
                        torre1.GetComponent<TorreBehaviourGalileo>().posizione -= 2;
                    }
                }
                if (torre2.transform.position.y - ((torreHeight * torrePrefab.transform.localScale.y) / 2) > Camera.main.orthographicSize)
                {
                    if (torre1.GetComponent<TorreBehaviourGalileo>().posizione - 2 >= 0)
                    {

                        tilesAttraversati--;
                        tilesScesi++;
                        torre2.transform.position = new Vector3(0, torre1.transform.position.y - (torreHeight * torrePrefab.transform.localScale.y));
                        torre2.GetComponent<TorreBehaviourGalileo>().posizione -= 2;
                    }
                }
            }
        }
        else
        {
            if (torreFondo != null)
            {
                if (torreFondo.transform.localPosition.y + 2 > Camera.main.orthographicSize)
                {
                    finoInFondo = false;
                    torreFondo = null;
                    caduta = false;
                }
            }
        }
	}

    private void restart()
    {
        //inFondo = false;
        finoInFondo = false;
    }

    private void stopCaduta()
    {
        caduta = false;
    }

    public void CADI()
    {
        caduta = true;
        //Se siamo all'inizio 
        if (torre1.GetComponent<TorreBehaviourGalileo>().posizione == 1 && torre2.GetComponent<TorreBehaviourGalileo>().posizione == 0
            || torre1.GetComponent<TorreBehaviourGalileo>().posizione == 0 && torre2.GetComponent<TorreBehaviourGalileo>().posizione == 1)
        {
            Debug.Log("FINO IN FONDO");
            if (torre1.transform.position.y < torre2.transform.position.y) torreFondo = torre1;
            else torreFondo = torre2;
            finoInFondo = true;
        }
        else
        {
            if (torre1.GetComponent<TorreBehaviourGalileo>().posizione < 2 || torre2.GetComponent<TorreBehaviourGalileo>().posizione<2)
                Invoke("stopCaduta", 1);
            else Invoke("stopCaduta", 2);
        }
    }

    void resume()
    {
        dc.resume();
    }
}