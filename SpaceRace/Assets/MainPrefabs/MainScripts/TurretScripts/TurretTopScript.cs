using UnityEngine;
using System.Collections;

public class TurretTopScript : MonoBehaviour {

	public float rotation_speed; // Drehgeschwindigkeit
	public float engage_distance; // Angriffsradius

	private float rotation_y = 0.0f;

	private GameObject currentTarget;



	private string targetTag = "DebugTarget";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		findTarget ();

		if (currentTarget != null) {

			Vector3 targetVector = currentTarget.transform.position - transform.position;

			Quaternion targetRotation = Quaternion.LookRotation (targetVector, transform.up);
			
			targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotation_speed * Time.deltaTime);
			
			transform.rotation = targetRotation;

		}

		transform.localRotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y, 0);


	}

	void findTarget(){

		float nearest = Mathf.Infinity;
		GameObject nearestObject = null;

		foreach (GameObject o in GameObject.FindGameObjectsWithTag(targetTag)) {

			float distance = Vector3.Distance (o.transform.position, transform.position);
			
			if (distance < nearest) {
				nearest = distance;
				nearestObject = o;
			}
			
		}

		currentTarget = nearestObject;



	}
}
