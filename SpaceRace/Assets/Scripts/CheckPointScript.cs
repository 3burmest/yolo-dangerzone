﻿using UnityEngine;
using System.Collections;

public class CheckPointScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			GameObject rc = GameObject.FindGameObjectWithTag("RaceController");
			rc.GetComponent<RaceController>().nextCheckpoint();
			Destroy(gameObject);
		}
	}
}
