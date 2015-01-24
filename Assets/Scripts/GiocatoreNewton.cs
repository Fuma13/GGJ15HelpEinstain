﻿using UnityEngine;
using System.Collections;

public class GiocatoreNewton : MonoBehaviour {

    public GameObject melaPrefab, barra;
    private int direzioneDelta;
    private float potenza, deltaPotenza, maxPotenza;
    private bool pressed;


	void Start () {
        potenza = 0;
        deltaPotenza = 5f;
        maxPotenza = 200;
        pressed = false;
        direzioneDelta = 1;
	}
	

	void Update () {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            pressed = true;
        }
        if(pressed)
        {
            potenza += deltaPotenza * direzioneDelta;
            if (potenza > maxPotenza || potenza < 0)
                direzioneDelta *= -1;
            Debug.Log(potenza);
            if(Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("KeyUp");
                Lancia(potenza);
                potenza = 0;
                pressed = false;
            }
        }
        barra.transform.localScale = new Vector3(potenza/10, barra.transform.localScale.y, barra.transform.localScale.z);
	}

    void Lancia(float pot)
    {
        Debug.Log("Lancio");
        GameObject mela = (GameObject)Instantiate(melaPrefab, transform.position, Quaternion.identity);
        mela.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * potenza);
    }
}
