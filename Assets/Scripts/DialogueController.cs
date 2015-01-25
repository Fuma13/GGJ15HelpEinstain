using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public string[] dialoghi;
    public Color cMilena = Color.black;
    public Color cEinstein = Color.white;
    public Color cGalileo = Color.gray;
    public Color cNewton = Color.green;
    public Text textBox;
    public GameObject prossimaScenaPrefab;
    public string prossimaScena;

    private int textTime;
    private bool canWrite = true;
    public bool paused = true; //False = autostart; True = startare tramite la funzione resume()
    private bool finished = false;
    private char style;
    private int count = 0;

	// Use this for initialization
	void Start () {
        //textBox = Canvas.FindObjectOfType<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!paused && !finished)
        {
            if (textBox.text.Equals("") && canWrite)
            {
                if (dialoghi.Length > count)
                {
                    string line = dialoghi[count];
                    ++count;
                    style = line[0];
                    
                    if (style != 'P')
                    {
                        textBox.text = line.Substring(1);
                        /*if (style == 'M') textBox.color = mColor;
                        else textBox.color = fColor;*/
                        if (style == 'E') textBox.color = cEinstein;
                        else if (style == 'G') textBox.color = cGalileo;
                        else if (style == 'N') textBox.color = cNewton;
                        else textBox.color = cMilena;
                        if (style == 'Z')
                        {
                            finished = true;
                            textTime = 1;
                            GameObject next = Instantiate(prossimaScenaPrefab) as GameObject;
                            next.GetComponent<ProssimaScenaScript>().scena=prossimaScena;
                        }
                        else
                        {
                            textTime = textBox.text.Length * 3; //Più o meno, il tempo dovrebbe essere di più per frasi corte e meno del normale per frasi lunghe
                            canWrite = false;
                        }
                    }
                    else
                    {
                        paused = true;
                    }
                }
            }

            if (textTime < 0 && textBox.text != "")
            {
                textBox.text = "";
                textTime = 0;
                Invoke("yesYouCanWrite", 1);
            }
            else textTime--;
        }
	}

    private void yesYouCanWrite()
    {
        canWrite = true;
    }

    public void resume()
    {
        paused = false;
    }
}
