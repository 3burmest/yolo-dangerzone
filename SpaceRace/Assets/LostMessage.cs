using UnityEngine;
using System.Collections;

public class LostMessage : MonoBehaviour {

	public GameObject message;

	// Use this for initialization
	void Start () {
		if (Time.realtimeSinceStartup > 2) {
			message.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
