using UnityEngine;
using System.Collections;

public class MenuAnimation : MonoBehaviour {


	private Animator anim;
	public GameObject panel;

	// Use this for initialization
	void Start () {
		anim = panel.GetComponent<Animator> ();
		anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ShowMenu(){
		anim.enabled = true;
		anim.Play ("LoadingSlide");


	}

	public void HidePanel(){
			anim.Play ("SlideOut");

	}
}
