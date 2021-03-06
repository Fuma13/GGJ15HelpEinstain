﻿using UnityEngine;
using System.Collections;

public class PersonaggioNewton : MonoBehaviour {

    private int direzione;
    public float velocita = 2;
    private bool randomDirezione;
    public Sprite colpito, bernoccolo;
    public CircleCollider2D uccello;

	// Use this for initialization
	void Start () {
        direzione = 1;
        randomDirezione = false;

        Invoke("enableRandom", 2);
	}
	
	// Update is called once per frame
	void Update () {
		if (velocita > 0) {
						transform.Translate (new Vector2 (1, 0) * direzione * velocita * Time.deltaTime);

                        if (randomDirezione == true)
                        {
                            float random = Random.value;
                            if (random < 0.01f)
                                InvertiCamminata();
                        }
		}
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Limite")
        {
            InvertiCamminata();
        }

        //if(coll.gameObject.tag == "Ostacolo")
        //{
        //    Colpito();
        //}
	}
	
	void InvertiCamminata()
    {
        direzione *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
     public bool vincita()
    {
        return (velocita > 0) ? false : true;
    }

     public void enableRandom()
     {
         randomDirezione = true;
     }

    public void Colpito()
     {
         velocita = 0;
         GetComponent<Animator>().enabled = false;
         GetComponent<SpriteRenderer>().sprite = colpito;
         Invoke("Bernoccolo", 1);
         uccello.isTrigger = true;
     }
    private void Bernoccolo()
    {
        GetComponent<SpriteRenderer>().sprite = bernoccolo;

    }

}
