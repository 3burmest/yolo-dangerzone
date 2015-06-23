using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour {
	public int speed = 100;
	public int rotationSpeed = 10;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody>().AddRelativeTorque(-Vector3.forward * Input.GetAxis("Horizontal") * rotationSpeed);
		GetComponent<Rigidbody>().AddRelativeTorque(-Vector3.left * Input.GetAxis("Vertical") * (rotationSpeed/2));

		GetComponent<Rigidbody>().velocity = (transform.forward * speed);
	}
}
