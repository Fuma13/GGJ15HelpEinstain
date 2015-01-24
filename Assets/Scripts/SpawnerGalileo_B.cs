using UnityEngine;
using System.Collections;

public class SpawnerGalileo_B : MonoBehaviour {

    public float ritardo = 1.2f;
    public float inizioLancio = 1f;
    public GameObject roccia;
    public GameObject piuma;
    public float posRoccia = -4f;



	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", inizioLancio, ritardo);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn()
    {
        float ordine = Random.value;
        if (ordine < 0.5f)
        {
            Instantiate(roccia, new Vector3(posRoccia, 10, 0), Quaternion.identity);
            Instantiate(piuma, new Vector3(-posRoccia, 10, 0), Quaternion.identity);
        } else
        {
            Instantiate(roccia, new Vector3(-posRoccia, 10, 0), Quaternion.identity);
            Instantiate(piuma, new Vector3(posRoccia, 10, 0), Quaternion.identity);
        }
    }
}
