using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour {
	public int speed = 100;
	public int rotationSpeed = 10;
	Rigidbody rb;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddRelativeTorque(-Vector3.forward * Input.GetAxis("Horizontal") * rotationSpeed);
		rb.AddRelativeTorque(-Vector3.left * Input.GetAxis("Vertical") * rotationSpeed);
		rb.AddRelativeTorque(-Vector3.up * Input.GetAxis("LeftRight") * rotationSpeed);

		
		//rb.velocity += (transform.forward * speed);
		rb.velocity = Vector3.SmoothDamp(rb.velocity, transform.forward * speed, ref velocity, smoothTime);
	}
}
