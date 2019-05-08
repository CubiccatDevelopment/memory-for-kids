using UnityEngine;
using System.Collections;

public class Clapping : MonoBehaviour {


	public GameObject endfile;
	public Licznik endfilescript;


	void Start () {
		endfile=GameObject.FindGameObjectWithTag("LICZNIK"); 
		endfilescript=endfile.GetComponent<Licznik>();
	}
	
	// Update is called once per frame
	void Update () {
		if (endfilescript.end) {
			GetComponent<AudioSource> ().UnPause();
		} 
	
	}
	void Awake()
	{
		GetComponent<AudioSource> ().Pause ();
	}
}
