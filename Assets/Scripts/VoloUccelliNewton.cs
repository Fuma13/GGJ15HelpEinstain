using UnityEngine;
using System.Collections;

public class VoloUccelliNewton : MonoBehaviour {

	private Animator anim;
	private int direzione;
	public float velocita = 2;
	private int accelerazione;
	private bool presaLaMela;
	Vector2 angolo;

	private Vector3 posizioneInit;
	private Quaternion rotazioneInit;
	private Vector3 scaleInit;
	
	// Use this for initializationz
	void Start () {
		direzione = 1;
		presaLaMela = false;
		accelerazione = 1;
		anim = GetComponent<Animator> ();
		angolo = new Vector2 (1, 0);

		//mi salvo la posione iniziale dell'uccello
		posizioneInit = transform.position;
		scaleInit = transform.localScale;
		rotazioneInit = transform.rotation;

	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (""+posizioniIniziali.position.x + " " + posizioniIniziali.position.y);


		transform.Translate (angolo * direzione * velocita * accelerazione * Time.deltaTime);
		
		
		/*float random = Random.value;
		if (random < 0.01f)
			InvertiCamminata();*/
		
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Limite")
		{
			if ( presaLaMela== false  )
				InvertiCamminata();
		}
		if(coll.gameObject.tag == "Mela")
		{
			presaLaMela=true;
			rigidbody2D.isKinematic = true;
			Destroy( coll.gameObject );
			anim.SetTrigger("prendiMela");

			angolo = new Vector2(1,1*direzione);
			accelerazione +=1;
			Invoke ( "init" , 2);
		}
	}
	
	void InvertiCamminata()
	{
		direzione *= -1;
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}

	public void init(){
		//transform.position = new Vector3(posizioneInit.x,posizioneInit.y, posizioneInit.z);
		transform.position = posizioneInit;
		transform.rotation = rotazioneInit;
		transform.localScale = scaleInit;

		accelerazione = 1;
		//gameObject.transform.rotation = posizioniIniziali.rotation;

		//transform.position = new Vector3 (0.0f,0.0f,0.0f);
		//transform.localScale = new Vector3(1.0f, transform.localScale.y, transform.localScale.z);
		direzione = 1;
		presaLaMela = false;
		
		anim.SetTrigger ("resetUcelllo");
		angolo = new Vector2 (1, 0);

		rigidbody2D.isKinematic = false;


	}
    
}
