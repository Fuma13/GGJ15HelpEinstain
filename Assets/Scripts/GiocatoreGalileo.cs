using UnityEngine;
using System.Collections;

public class GiocatoreGalileo : MonoBehaviour {

    public float xPos = -4f;

    private RipetiTorreGalileo script;
    private bool fadein=false;
    private bool fadeout = false; 
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 1f;
    private float startTime;
    public SpriteRenderer sprite;
    public Sprite milevaInCima;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(xPos, transform.position.y, 0);
        script = Camera.main.GetComponent<RipetiTorreGalileo>();
        sprite = GetComponent<SpriteRenderer>();
        GetComponent<Animator>().Play("arrampicataMoglie");
	}
	
	// Update is called once per frame
	void Update () {
        if (!script.inCima) GetComponent<Animator>().Play("arrampicataMoglie");

        if (!script.caduta)
        {
            transform.rotation = Quaternion.identity;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.position = new Vector3(-transform.localPosition.x, transform.position.y, 0);
            }
        }
        else
        {
            transform.Rotate(new Vector3(0f, 0f, 100f) * Time.deltaTime);
        }
        /*
        if (fadein)
        {
            float t = (Time.time - startTime) / duration;
            sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));
        }

        if (fadeout)
        {
            float t = (Time.time - startTime) / duration;
            sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t)); 
        }*/
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ostacolo" && !script.caduta)
        {
            //script.caduta = true;
            script.CADI();
            Debug.Log("HIT!!");
            audio.Play();
        }
    }

    public void startFadeIn()
    {
        startTime = Time.time;
        fadein = true;
        GetComponent<Animator>().Play("fadeInMoglie");
        sprite.sprite = milevaInCima;
        this.transform.localScale = new Vector3(-0.3f, 0.3f, 1f);
        Debug.Log("mi fadeinizzone");
    }
    public void startFadeOut()
    {
        startTime = Time.time;
        fadeout = true;
        GetComponent<Animator>().Play("fadeOutMoglie");
        Debug.Log("mi fadeoutzzone");
    }
}
