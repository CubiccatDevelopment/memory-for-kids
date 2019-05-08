using UnityEngine;
using System.Collections;

public class CubeRotate2 : MonoBehaviour {
	public GameObject licznik;
	public Licznik licznikscript;
	int stop,iloscElementow;
	public bool x,y;

	float speed = 6.0f;

	void Start(){
		x = false;
		iloscElementow = GameObject.FindGameObjectsWithTag ("Box").Length;  //POCZATKOWA ILOSC ELEMENTOW
		licznik = GameObject.FindGameObjectWithTag("LICZNIK");  // WYSZUKUJE FUNKCJI
		licznikscript = licznik.GetComponent<Licznik>();


		transform.rotation = Quaternion.Euler (0, 0, 0);
		transform.Rotate (0, 0, 0);


	}

	void Update() {
		stop = GameObject.FindGameObjectsWithTag ("Box").Length;	// AKTUALNA ILOSC NIEOBROCONYCH ELEMENTOW

		if (transform.rotation.y==-1) {
			transform.rotation = Quaternion.Euler (0, 180, 0);
			transform.Rotate (0, 0, 0);
			x = false;
		}

		Debug.Log (transform.rotation.y);

		if (x) {
			obrot ();
			transform.tag = "Kot";
		}

		if (licznikscript.y) {
			powrot ();
			if (transform.rotation.y < (0.001)) {
				transform.rotation = Quaternion.Euler (0, 0, 0);
				transform.Rotate (0, 0, 0);
				y = false;
			}
		}
	}

	void OnMouseDown() {
		if (stop>iloscElementow-2-licznikscript.zniszczone) {										//SPRAWDZA CZY SĄ MAKSYMALNIE 2 OBRÓCONE KOSTKI
			if ( transform.rotation.y == 0) {			//SPRAWDZA CZY KOSTKI SĄ W POZYCJI NIEUZYTEJ
				y=false;
				x=true;
			}

		}
	}

	void obrot(){


			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, 180, 0), Time.deltaTime * speed);

	}
	void powrot(){

		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, 0, 0), Time.deltaTime * speed);

	}
		

}