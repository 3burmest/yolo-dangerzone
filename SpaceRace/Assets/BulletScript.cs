using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float speed = 10f;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddRelativeForce (new Vector3 (0, 0, 1) * speed, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
