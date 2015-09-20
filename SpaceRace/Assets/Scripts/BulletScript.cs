using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float speed = 10f;
	public float lifeTime = 2.0F;

	private Rigidbody rb;
	private float startTime;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddRelativeForce (new Vector3 (0, 0, 1) * speed, ForceMode.Impulse);
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeTime < Time.time - startTime) {
			Destroy(gameObject);
		}
	}
}
