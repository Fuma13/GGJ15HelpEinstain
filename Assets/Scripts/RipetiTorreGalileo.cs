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
    private GameObject torreFondo=null;
    private bool inCima = false;

	// Use this for initialization
	void Start () {
        torreHeight = torrePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        torre1 = (GameObject)Instantiate(torrePrefab, Vector3.zero, Quaternion.identity);
        torre1.GetComponent<TorreBehaviourGalileo>().posizione = 0;
        torre2 = (GameObject)Instantiate(torrePrefab, new Vector3(0, torre1.transform.position.y + (torreHeight * torrePrefab.transform.localScale.y), 0), Quaternion.identity);
        torre2.GetComponent<TorreBehaviourGalileo>().posizione = 1;
    }
	
	// Update is called once per frame
	void Update () {
        
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

        if (inCima && tilesAttraversati < tilesPerLaCima)
        {
            inCima = false;
        }

        if (!finoInFondo)
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
                    tilesAttraversati--;
                    tilesScesi++;
                    torre1.transform.position = new Vector3(0, torre2.transform.position.y - (torreHeight * torrePrefab.transform.localScale.y));
                    torre1.GetComponent<TorreBehaviourGalileo>().posizione -= 2;
                }
                if (torre2.transform.position.y - ((torreHeight * torrePrefab.transform.localScale.y) / 2) > Camera.main.orthographicSize)
                {
                    tilesAttraversati--;
                    tilesScesi++;
                    torre2.transform.position = new Vector3(0, torre1.transform.position.y - (torreHeight * torrePrefab.transform.localScale.y));
                    torre2.GetComponent<TorreBehaviourGalileo>().posizione -= 2;
                }
            }
        }
        else
        {
            if (torreFondo != null)
            {
                if (torreFondo.transform.localPosition.y + 2 > Camera.main.orthographicSize)
                {
                    Debug.Log("in fondo");
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
        else if (torre1.GetComponent<TorreBehaviourGalileo>().posizione == 2 && torre2.GetComponent<TorreBehaviourGalileo>().posizione == 1
            || torre1.GetComponent<TorreBehaviourGalileo>().posizione == 1 && torre2.GetComponent<TorreBehaviourGalileo>().posizione == 2)
        {
            Debug.Log("FINO IN FONDO CON CAMBIO");
            if (torre1.GetComponent<TorreBehaviourGalileo>().posizione >= 1 && torre2.GetComponent<TorreBehaviourGalileo>().posizione >= 1)
            {
                if (torre1.transform.localPosition.y < torre2.transform.localPosition.y)
                {
                    Debug.Log("1 <-> 2");
                    tilesAttraversati--;
                    tilesScesi++;
                    torre2.transform.position = new Vector3(0, torre1.transform.position.y - (torreHeight * torrePrefab.transform.localScale.y));
                    torre2.GetComponent<TorreBehaviourGalileo>().posizione -= 2;
                    torreFondo = torre2;
                }
                else
                {
                    Debug.Log("2 <-> 1");
                    tilesAttraversati--;
                    tilesScesi++;
                    torre1.transform.position = new Vector3(0, torre2.transform.position.y - (torreHeight * torrePrefab.transform.localScale.y));
                    torre1.GetComponent<TorreBehaviourGalileo>().posizione -= 2;
                    torreFondo = torre1;
                }
            }
            finoInFondo = true;
        }
        else
        {
            Invoke("stopCaduta", 2);
        }
    }
}




/*public class RipetiTorreGalileo : MonoBehaviour {

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
    public Sprite inizio, fine, standard;
    //COMMANDO PATTERN!
    [HideInInspector]
    public bool inFondo = false;
    private GameObject torreFondo=null;
    private bool inCima = false;

	// Use this for initialization
	void Start () {
        torreHeight = torrePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        torre1 = (GameObject)Instantiate(torrePrefab, Vector3.zero, Quaternion.identity);
        torre2 = (GameObject)Instantiate(torrePrefab, new Vector3(0, torre1.transform.position.y + (torreHeight * torrePrefab.transform.localScale.y), 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        
        Debug.Log("Tiles attraversati: "+tilesAttraversati);
        if (torreFondo != null && !inFondo)
        {
            if (torreFondo.transform.localPosition.y + 2 > Camera.main.orthographicSize)
            {
                inFondo = true;
                torreFondo = null;
                caduta = false;
                Invoke("restart", 1);
            }
        }

        if (inCima && tilesAttraversati < tilesPerLaCima)
        {
            inCima = false;
        }

        //Se sto cadendo
        if (caduta)
        {
            if (tilesAttraversati>1)
            {
                if (torre1.transform.position.y - ((torreHeight * torrePrefab.transform.localScale.y) / 2)> Camera.main.orthographicSize)
                {
                    torre1.GetComponent<SpriteRenderer>().sprite = standard;
                    tilesAttraversati--;
                    tilesScesi++;
                    torre1.transform.position = new Vector3(0, torre2.transform.position.y - (torreHeight * torrePrefab.transform.localScale.y));
                }
                if (torre2.transform.position.y - ((torreHeight * torrePrefab.transform.localScale.y) / 2) > Camera.main.orthographicSize)
                {
                    torre2.GetComponent<SpriteRenderer>().sprite = standard;
                    tilesAttraversati--;
                    tilesScesi++;
                    torre2.transform.position = new Vector3(0, torre1.transform.position.y - (torreHeight * torrePrefab.transform.localScale.y));
                }
            }
            else
            {
                if (tilesAttraversati <= 1 && torreFondo==null)
                {
                    if (torre1.transform.position.y - ((torreHeight * torrePrefab.transform.localScale.y) / 2) > Camera.main.orthographicSize)
                    {
                        torre1.GetComponent<SpriteRenderer>().sprite = inizio;
                        tilesAttraversati--;
                        tilesScesi++;
                        torre1.transform.position = new Vector3(0, torre2.transform.position.y - (torreHeight * torrePrefab.transform.localScale.y));
                        torreFondo = torre1;
                    }
                    if (torre2.transform.position.y - ((torreHeight * torrePrefab.transform.localScale.y) / 2) > Camera.main.orthographicSize)
                    {
                        torre2.GetComponent<SpriteRenderer>().sprite = inizio;
                        tilesAttraversati--;
                        tilesScesi++;
                        torre2.transform.position = new Vector3(0, torre1.transform.position.y - (torreHeight * torrePrefab.transform.localScale.y));
                        torreFondo = torre2;
                    }
                }
            }
            //Se siamo caduti per il numero scelto di tiles
            if (tilesScesi>=tilesDaScendere)
            {
                caduta = false;
                tilesScesi = 0;
            }
        }
        //Non sto cadendo
        else if (!inCima)
        {
            if (torre1.transform.position.y + ((torreHeight * torrePrefab.transform.localScale.y) / 2) < -Camera.main.orthographicSize)
            {
                if (tilesAttraversati >= tilesPerLaCima)
                {
                    torre1.GetComponent<SpriteRenderer>().sprite = fine;
                    inCima = true;
                }
                else
                {
                    torre1.GetComponent<SpriteRenderer>().sprite = standard;
                    inCima = false;
                }
                tilesAttraversati++;
                torre1.transform.position = new Vector3(0, torre2.transform.position.y + (torreHeight * torrePrefab.transform.localScale.y));
            }
            if (torre2.transform.position.y + ((torreHeight * torrePrefab.transform.localScale.y) / 2) < -Camera.main.orthographicSize)
            {
                if (tilesAttraversati >= tilesPerLaCima)
                {
                    torre2.GetComponent<SpriteRenderer>().sprite = fine;
                    inCima = true;
                }
                else
                {
                    torre2.GetComponent<SpriteRenderer>().sprite = standard;
                    inCima = false;
                }
                tilesAttraversati++;
                torre2.transform.position = new Vector3(0, torre1.transform.position.y + (torreHeight * torrePrefab.transform.localScale.y));
            }
        }
	}

    private void restart()
    {
        inFondo = false;
    }
}
*/