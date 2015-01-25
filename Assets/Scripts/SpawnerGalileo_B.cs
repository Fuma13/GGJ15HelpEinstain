using UnityEngine;
using System.Collections;

public class SpawnerGalileo_B : MonoBehaviour {

    public float ritardo = 1.2f;
    public float inizioLancio = 1f;
    public GameObject roccia;
    public GameObject barile;
    public float posRoccia = -4f;
    public float posYRoccia = 10;

    private RipetiTorreGalileo script;
    private Animator animator;
    private bool STOP = false;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", inizioLancio, ritardo);
        script = Camera.main.GetComponent<RipetiTorreGalileo>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (script && script.caduta)
            EliminaOstacoli();
	}

    void Spawn()
    {
        if (!STOP)
        {
            if (!script || !script.caduta)
            {
                float ordine = Random.value;
                if (ordine < 0.5f)
                {
                    Instantiate(roccia, new Vector3(posRoccia + transform.position.x, posYRoccia + transform.position.y, 0), Quaternion.identity);
                    Instantiate(barile, new Vector3(-posRoccia + transform.position.x, posYRoccia + transform.position.y, 0), Quaternion.identity);
                    if (animator)
                        animator.SetTrigger("Restart");
                }
                else
                {
                    Instantiate(roccia, new Vector3(-posRoccia + transform.position.x, posYRoccia + transform.position.y, 0), Quaternion.identity);
                    Instantiate(barile, new Vector3(posRoccia + transform.position.x, posYRoccia + transform.position.y, 0), Quaternion.identity);
                    if (animator)
                        animator.SetTrigger("Restart");
                }
            }
        }
    }

    void EliminaOstacoli()
    {
        //GameObject[] ostacoli = GameObject.FindGameObjectsWithTag("Ostacolo");
        //foreach (GameObject ostacolo in ostacoli)
        //{
        //    Destroy(ostacolo);
        //}

    }

    public void PLEASE_STOP()
    {
        STOP = true;
        GameObject[] ostacoli = GameObject.FindGameObjectsWithTag("Ostacolo");
        foreach (GameObject ostacolo in ostacoli)
        {
            Destroy(ostacolo);
        }
    }

}
