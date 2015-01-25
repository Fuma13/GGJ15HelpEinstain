using UnityEngine;
using System.Collections;

public class GiocatoreNewton : MonoBehaviour {

    public GameObject melaPrefab, barra;
    private int direzioneDelta;
    private float potenza, deltaPotenza, maxPotenza;
    private bool pressed;
	private bool haSparato;
	private bool abilitosparo;


	void Start () {

		haSparato = false;
        potenza = 0;
        deltaPotenza = 5f;
        maxPotenza = 250;
        pressed = false;
        direzioneDelta = 1;
		abilitosparo = false;
	}
	

	void Update () {

		if (abilitosparo == true) {
						if (Input.GetKeyDown (KeyCode.Space) && haSparato == false) {
								pressed = true;

						}
						if (pressed) {
								potenza += deltaPotenza * direzioneDelta;
								if (potenza > maxPotenza || potenza < 0)
										direzioneDelta *= -1;

								if (Input.GetKeyUp (KeyCode.Space)) {
                                    audio.Play();
										Lancia (potenza);
										potenza = 0;
										pressed = false;
										haSparato = true;
										Invoke ("resetSparo", 0.5f);

								}
						}

						//barra.transform.localScale = new Vector3(potenza/10, barra.transform.localScale.y, barra.transform.localScale.z);
						//barra.transform.localPosition = (new Vector3(1, barra.transform.localPosition.y, 0) * deltaPotenza*2);
				}
	}

    void Lancia(float pot)
    {
        GameObject mela = (GameObject)Instantiate(melaPrefab, transform.position, Quaternion.identity);
        mela.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * potenza);
    }

	void resetSparo(){

		haSparato = false;

		}

	public void abilitoSparo(bool value){
		abilitosparo = value;
		}

   

}
