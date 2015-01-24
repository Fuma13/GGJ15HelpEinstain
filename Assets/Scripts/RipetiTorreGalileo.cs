using UnityEngine;
using System.Collections;

public class RipetiTorreGalileo : MonoBehaviour {

    public GameObject torrePrefab;
    private GameObject torre1, torre2;
    private float torreHeight;
    //COMMANDO PATTERN!
    [HideInInspector]
    public bool caduta = false;

	// Use this for initialization
	void Start () {
        torreHeight = torrePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        torre1 = (GameObject)Instantiate(torrePrefab, Vector3.zero, Quaternion.identity);
        torre2 = (GameObject)Instantiate(torrePrefab, new Vector3(0, torre1.transform.position.y + (torreHeight * torrePrefab.transform.localScale.y), 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Keypad1) && !caduta)
        {
            caduta = true;
        }

        if (caduta)
        {
            if (torre1.transform.position.y - ((torreHeight * torrePrefab.transform.localScale.y) / 2) > Camera.main.orthographicSize)
            {
                Debug.Log("Uscito!");
                torre1.transform.position = new Vector3(0, torre2.transform.position.y + (torreHeight * torrePrefab.transform.localScale.y));
            }
            if (torre2.transform.position.y - ((torreHeight * torrePrefab.transform.localScale.y) / 2) > Camera.main.orthographicSize)
            {
                Debug.Log("Uscito!");
                torre2.transform.position = new Vector3(0, torre1.transform.position.y + (torreHeight * torrePrefab.transform.localScale.y));
            }
        }
        else
        {
            if (torre1.transform.position.y + ((torreHeight * torrePrefab.transform.localScale.y) / 2) < -Camera.main.orthographicSize)
            {
                Debug.Log("Uscito!");
                torre1.transform.position = new Vector3(0, torre2.transform.position.y + (torreHeight * torrePrefab.transform.localScale.y));
            }
            if (torre2.transform.position.y + ((torreHeight * torrePrefab.transform.localScale.y) / 2) < -Camera.main.orthographicSize)
            {
                Debug.Log("Uscito!");
                torre2.transform.position = new Vector3(0, torre1.transform.position.y + (torreHeight * torrePrefab.transform.localScale.y));
            }
        }
	}
}
