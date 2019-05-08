using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scenemenager : MonoBehaviour {
	public GameObject Audio;
	public Animator anim;
	public GameObject panel;
	public int x;
	// Use this for initialization
	void Start () {
		anim = panel.GetComponent<Animator> ();
		anim.enabled = false;

		Audio = GameObject.FindGameObjectWithTag ("Audio");

			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void RELOAD(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
		}

	public void MenuLoad(){
		SceneManager.LoadScene (0);
		x = 0;
		Time.timeScale = 1;

	}
	public void LevelEasyLoad(){
		
		x = 1;
		StartCoroutine (Load ());
		Time.timeScale = 1;
	}
	public void LevelMediunLoad(){
		x = 2;
		StartCoroutine (Load ());
		Time.timeScale = 1;
	}
	public void ShowMenuL(){
		anim.enabled = true;
		anim.Play ("LoadingSlide");


	}
	public void Link(){
			Application.OpenURL ("https://web.facebook.com/KindOfStudio");
	}
		
	IEnumerator Load(){
		ShowMenuL ();
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene (x);
	}
}
