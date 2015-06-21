using UnityEngine;
using System.Collections;

public class RocketMover : MonoBehaviour { 

	public GameObject target;
	public float speed;
	public float angularSpeed;

//	private Rigidbody rb;


	// Use this for initialization
	void Start () {
//		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (target == null) {
			Destroy(gameObject);
			return;
		}

		Vector3 direction = target.transform.position - transform.position;


		float step = angularSpeed * Time.deltaTime;

		Vector3 newDir = Vector3.RotateTowards(transform.forward, direction, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);


		transform.position += transform.forward * speed;


	}
}
