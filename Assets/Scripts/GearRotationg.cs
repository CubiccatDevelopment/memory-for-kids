using UnityEngine;
using System.Collections;

public class GearRotationg : MonoBehaviour {
	public int director = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, director);
	}
}
