using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelMenager : MonoBehaviour {
	
	private Animator anim;
	private bool panelDisplayed;
	public GameObject panel;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		anim = panel.GetComponent<Animator> ();
		anim.enabled = false;
		panelDisplayed = false;

	}
	public void ShowMenu(){
		anim.enabled = true;
		anim.Play ("Slide");
		panelDisplayed = true;


	}

	public void HidePanel(){
		if(panelDisplayed){
			panelDisplayed = false;
			anim.Play ("SlideOut");
		}
	}
}
