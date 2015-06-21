using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material.color = Color.green;
		gameObject.tag = "Powerup";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
