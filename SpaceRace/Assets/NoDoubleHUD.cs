using UnityEngine;
using System.Collections;

public class NoDoubleHUD : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		if(FindObjectsOfType(GetType()).Length > 1) {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
