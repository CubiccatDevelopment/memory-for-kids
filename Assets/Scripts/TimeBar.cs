using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeBar : MonoBehaviour {
	public GameObject licznik;
	public Licznik licznikscript;
	private Animator anim;
	private bool panelDisplayed;
	public GameObject panel;
	public float time=300.0f, timing=0.0f;
	float startTime;
	public Text punkty;
	public Text WinOrLose;
	public Text Record;


	// Use this for initialization
	void Start () {
		startTime = time;
		licznik = GameObject.FindGameObjectWithTag("LICZNIK");  // WYSZUKUJE FUNKCJI
		licznikscript = licznik.GetComponent<Licznik>();
		anim = panel.GetComponent<Animator> ();
		anim.enabled = false;
		panelDisplayed = false;

	}
	
	// Update is called once per frame
	void Update () {


		timing = timing + Time.deltaTime;
		if (SceneManager.GetActiveScene().buildIndex == 1) {
			Record.text = "Record: " + PlayerPrefs.GetInt ("RecordEASY",100) + "s";
		}
		else if (SceneManager.GetActiveScene().buildIndex == 2) {
			Record.text = "Record: " + PlayerPrefs.GetInt ("RecordMEDIUM",300) + "s";
		}




		if (!licznikscript.end) {
			WinOrLose.text = "Keep going!";
		} else {
			WinOrLose.text = "Congratulation!";
			if (SceneManager.GetActiveScene().buildIndex == 1) {
				if (PlayerPrefs.GetInt ("RecordEASY",100) > ((int)timing)) {
					PlayerPrefs.SetInt ("RecordEASY", ((int)timing));
					Record.text = "Record: " + PlayerPrefs.GetInt ("RecordEASY") + "s";
				}
			}
			else if(SceneManager.GetActiveScene().buildIndex == 2) {
				Debug.Log(PlayerPrefs.GetInt("RecordMEDIUM"));
					Debug.Log((int)timing);
				if (PlayerPrefs.GetInt ("RecordMEDIUM",300) > ((int)timing)) {
					Debug.Log (SceneManager.GetActiveScene ().buildIndex);
					PlayerPrefs.SetInt ("RecordMEDIUM", ((int)timing));
					Record.text = "Record: " + PlayerPrefs.GetInt ("RecordMEDIUM") + "s";
				}
			}

		}

		time -= Time.deltaTime;
		if (time <= 0) {
			WinOrLose.text = "You lose!";
			ShowMenu ();
			punkty.text =  "Time: "+((int)timing+"s");
		}

		if (Input.GetKeyUp (KeyCode.Escape) && !panelDisplayed &&!licznikscript.end) {
			ShowMenu ();
		}
		if (licznikscript.end) {
			ShowMenu ();
			panelDisplayed = false;
		}
			
	
	}
	public void ShowMenu(){
		punkty.text = "Time: "+((int)timing+"s");
			anim.enabled = true;
			anim.Play ("Slide");
			panelDisplayed = true;
			Time.timeScale = 0;

	}

	public void HidePanel(){
		if (!licznikscript.end&&time>0) {
			panelDisplayed = false;
			anim.Play ("SlideOut");
			Time.timeScale = 1;
		}
	}

}
