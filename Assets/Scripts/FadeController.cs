using UnityEngine;
using System.Collections;

public class FadeController : MonoBehaviour {
	public float FADE_SPEED = 0.1f;
	private bool fadeOn;
    private SpriteRenderer SRenderer;

	// Use this for initialization
	void Start () {
        SRenderer = GetComponent<SpriteRenderer>();
		this.fadeOn = false;
//		this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.fadeOn){
            if (SRenderer.color.a > 0)
            {
                SRenderer.color = new Color(SRenderer.color.r,
                                                            SRenderer.color.g,
                                                            SRenderer.color.b,
                                                            SRenderer.color.a - FADE_SPEED);
			}else{
				this.enabled = false;
			}
		}else{
            if (SRenderer.color.a < 1)
            {
                SRenderer.color = new Color(SRenderer.color.r,
                                                            SRenderer.color.g,
                                                            SRenderer.color.b,
                                                            SRenderer.color.a + FADE_SPEED);
			}else{
				this.enabled = false;
			}
		}
	}

	public void FadeOn(){
		this.fadeOn = true;
		this.enabled = true;
	}

	public void FadeOff(){
		this.fadeOn = false;
		this.enabled = true;
	}
}
