using UnityEngine;
using System.Collections;

public class SpawnerGalileo_A : MonoBehaviour {

    public float ritardo = 1.2f;
    public float inizioLancio = 1f;
    public GameObject roccia;
    public GameObject barile;
    public float posRoccia = -4f;

    private RipetiTorreGalileo script;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", inizioLancio, ritardo);
        script = Camera.main.GetComponent<RipetiTorreGalileo>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void Spawn()
    {
        if (!script.caduta)
        {
            float selectLancio = Random.value;

            if (selectLancio < 0.5f)
            {
                Lancio1();
            }
            else
            {
                Lancio2();
            }
        }
        
    }

    void Lancio1()
    {
        float selectOggetto = Random.value;

        if (selectOggetto < 0.5f)
        {
            Instantiate(roccia, new Vector3(posRoccia, 10, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(barile, new Vector3(-posRoccia, 10, 0), Quaternion.identity);
        }
    }

    void Lancio2()
    {
        float selectOggetto = Random.value;

        if (selectOggetto < 0.5f)
        {
            Instantiate(roccia, new Vector3(-posRoccia, 10, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(barile, new Vector3(posRoccia, 10, 0), Quaternion.identity);
        }
    }
}
