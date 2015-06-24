using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {
	public Transform target;
	public float followRotationSpeed = 0.1F;
	public float smoothPositionTime = 0.3F;
	public int distance = 20;

	Vector3 velocity = Vector3.zero;
	
	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate () {
		if(Input.GetKey(KeyCode.LeftShift)) {
			//Nach hinten gucken
		} else {
			//Finde ich sieht besser aus
			transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, followRotationSpeed);
			//Wäre eine alternative.. Ist aber miener Meinung nach weniger intuitiv
			/*transform.LookAt(target.position, target.up);*/
		}

		transform.position = Vector3.SmoothDamp(transform.position, target.position - target.forward * distance, ref velocity, smoothPositionTime);
	}
}
