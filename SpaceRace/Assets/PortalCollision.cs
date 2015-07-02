using UnityEngine;
using System.Collections;

public class PortalCollision : MonoBehaviour {
	public string scene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision c) {
		Application.LoadLevel(scene);
		Debug.Log("Neue Scene laden");
	}
}
