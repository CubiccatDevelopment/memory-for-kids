using UnityEngine;
using System.Collections;

public class ClappingLosing : MonoBehaviour {


	public GameObject endfile;
	public Licznik endfilescript;
	public float time=300.0f;


	void Start () {
		endfile=GameObject.FindGameObjectWithTag("LICZNIK"); 
		endfilescript=endfile.GetComponent<Licznik>();
	}

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (!endfilescript.end&&time<=0) {
			GetComponent<AudioSource> ().UnPause();
		} 

	}
	void Awake()
	{
		GetComponent<AudioSource> ().Pause ();
	}
}
