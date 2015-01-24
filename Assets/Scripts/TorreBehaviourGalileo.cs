using UnityEngine;
using System.Collections;

public class TorreBehaviourGalileo : MonoBehaviour {

    public int speed;
    private RipetiTorreGalileo script;

	// Use this for initialization
	void Start () {
        script = Camera.main.GetComponent<RipetiTorreGalileo>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!script.inFondo)
        {
            if (!script.caduta)
                this.transform.position = new Vector3(0, this.transform.localPosition.y - speed * Time.deltaTime, 0);
            else
                this.transform.position = new Vector3(0, this.transform.localPosition.y + (2 * speed) * Time.deltaTime, 0);
        }
    }
}
