using UnityEngine;
using System.Collections;

public class Licznik : MonoBehaviour {

	GameObject[] Wybrane;
	GameObject[] Wybrane2;
	GameObject[] VER;
	public int ilosc,zniszczone;
	public int veryfication,iloscElementow,stop,time=0;
	public bool y,end;
	float wait_time=0.5f;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		end = false;
		y = false;
		ilosc = 0;
		zniszczone = 0;
		iloscElementow = GameObject.FindGameObjectsWithTag ("Box").Length;
	}

	// Update is called once per frame
	void Update () {
		stop = GameObject.FindGameObjectsWithTag ("Box").Length;
		veryfication = GameObject.FindGameObjectsWithTag ("Kot").Length;


		if (veryfication == 2) {
	
			DestroyObjects ();

			VER = GameObject.FindGameObjectsWithTag ("Kot");

			if (VER [0].gameObject.transform.rotation.y == 1 && VER [1].gameObject.transform.rotation.y == 1) {
				StartCoroutine (wait_a_moment ());
			}
		} 

		if (stop + veryfication == 0)
			end = true;
	}


	void DestroyObjects(){				//FUNKCJA WYSZUKUJE I WYWOŁUJE FUNKCJĘ NISZCZ

		Wybrane = GameObject.FindGameObjectsWithTag ("Kot");

		if (Wybrane [0].gameObject.GetComponentInChildren<SpriteRenderer> ().sprite == Wybrane [1].gameObject.GetComponentInChildren<SpriteRenderer> ().sprite) {
			StartCoroutine (niszcz ());
			time = 0;
		}

	}

	public void Sync(){
		Wybrane2 = GameObject.FindGameObjectsWithTag ("Kot");
		Wybrane2[1].gameObject.transform.rotation = Wybrane [0].gameObject.transform.rotation;

	}



	IEnumerator niszcz (){				//FUNKCJA NISZCZY OBIEKT PO UPŁYWIE 1 SEKUNDY
		yield return new WaitForSeconds (1);
		for (int i = 0; i < GameObject.FindGameObjectsWithTag ("Kot").Length; i++) {
			Destroy (Wybrane [i]);
		}
		zniszczone=zniszczone+2;
		gameObject.SetActive (false);
		gameObject.SetActive (true);
	}

	IEnumerator wait_a_moment() {
		yield return new WaitForSeconds (wait_time);
		y = true;
	}
		
}
