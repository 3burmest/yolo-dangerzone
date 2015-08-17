using UnityEngine;
using System.Collections;

public class lifetime : MonoBehaviour {

	float start;
	public float time = 1.0f;

	// Use this for initialization
	void Start () {
		start = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.fixedTime - start >= time) {
			Destroy(gameObject);
		}
	}
}
