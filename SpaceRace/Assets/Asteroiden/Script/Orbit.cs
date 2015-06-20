using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {

	public Transform target;

	Vector3 startPosition;

	public float pos;
	public float speed;
	public float destroyRad;

	float radius;


	void Start(){

		startPosition = transform.position;

		radius = Vector3.Distance (startPosition, target.position);
	}
	
	// Update is called once per frame
	void Update () {

		float winkelgeschw = speed / radius;

//		pos += Time.deltaTime * Mathf.Pow(speed, 3);
		pos += Time.deltaTime * winkelgeschw; 

		// 0 <= pos <= 2*PI
		pos = pos > 2 * Mathf.PI ? pos - 2 * Mathf.PI : pos;

		// Neue Position ermitteln
		transform.position = target.position + new Vector3 (Mathf.Sin(pos) * radius, startPosition.y, Mathf.Cos(pos) * radius);
	
		if (pos > destroyRad) {
			Destroy(gameObject);
		}
	}
}
