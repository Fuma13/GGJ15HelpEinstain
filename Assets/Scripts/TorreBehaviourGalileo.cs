using UnityEngine;
using System.Collections;

public class TorreBehaviourGalileo : MonoBehaviour {

    public int speed;
    private RipetiTorreGalileo script;
    public int posizione;
    public Sprite inizio, fine, standard;

	// Use this for initialization
	void Start () {
        script = Camera.main.GetComponent<RipetiTorreGalileo>();
	}
	
	// Update is called once per frame
	void Update () {
        if (posizione==0)
            GetComponent<SpriteRenderer>().sprite = inizio;
        else if (posizione == script.tilesPerLaCima)
            GetComponent<SpriteRenderer>().sprite = fine;
        else GetComponent<SpriteRenderer>().sprite = standard;

        if (!script.stop)
        {
            if (!script.caduta)
                this.transform.position = new Vector3(0, this.transform.localPosition.y - speed * Time.deltaTime, 0);
            else
                this.transform.position = new Vector3(0, this.transform.localPosition.y + (2 * speed) * Time.deltaTime, 0);
        }
    }
}
