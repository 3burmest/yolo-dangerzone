using UnityEngine;
using System.Collections;

public class TurretGunScript : MonoBehaviour {

	public float rotation_speed;

	private float rotation_x;

	private GameObject currentTarget;

	private float max_x = 275;
	private float min_x = 390;

	
	private string targetTag = "DebugTarget";

	// Use this for initialization
	void Start () {
		rotation_x = transform.localRotation.eulerAngles.x;
	}
	
	// Update is called once per frame
	void Update () {

		findTarget ();

		if (currentTarget != null) {
			
			Vector3 targetVector = currentTarget.transform.position - transform.position;
			
			Quaternion targetRotation = Quaternion.LookRotation (targetVector, transform.forward);

			Debug.DrawRay(transform.position, transform.forward * 1000, Color.blue);
			
			transform.rotation = targetRotation;
			
		}

		rotation_x = rotateTowards (rotation_x, transform.localRotation.eulerAngles.x, rotation_speed);
		Debug.Log (rotation_x);

		if (rotation_x > 25 && rotation_x < 280) {
			if(rotation_x - 25 < 280 - rotation_x){
				rotation_x = 25;
			}
			else{
				rotation_x = 280;
			}
		}

		transform.localRotation = Quaternion.Euler (rotation_x, 0, 0);

	}

	float rotateTowards(float from, float to, float speed){

		from = from < 180 ? from + 360 : from;
		to = to < 180 ? to + 360 : to;

		float x;

		float dx = to - from; // Weg zum Ziel
		float ds = speed * Time.deltaTime * (dx < 0 ? -1 : 1); // Weg der in diesem Aufruf überbrückt werden kann

		if (Mathf.Abs (dx) > Mathf.Abs (ds)) {
			x = from + ds;
		} else {
			x = to;
		}

		return x % 360;
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
