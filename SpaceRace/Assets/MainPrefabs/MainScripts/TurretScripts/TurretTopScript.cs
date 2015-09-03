using UnityEngine;
using System.Collections;

public class TurretTopScript : MonoBehaviour {

	public float rotation_speed; // Drehgeschwindigkeit
	public float engage_distance; // Angriffsradius

	private float rotation_y = 0.0f;

	private GameObject currentTarget;

	private float delta_rotation = 0.0f;

	private string targetTag;

	public bool restrictRotation;

	public float beginDegree;

	public float endDegree;

	// Use this for initialization
	void Start () {
		targetTag = transform.parent.GetComponent<TargetScript> ().target;
	}
	
	// Update is called once per frame
	void Update () {

		findTarget ();

		if (currentTarget != null) {

			Vector3 targetVector = currentTarget.transform.position - transform.position;

			Quaternion targetRotation = Quaternion.LookRotation (targetVector, transform.up);
			
			targetRotation = Quaternion.RotateTowards (transform.rotation, targetRotation, rotation_speed * Time.deltaTime);

			float euler1 = transform.localRotation.eulerAngles.y;

			transform.rotation = targetRotation;

			delta_rotation = Mathf.Abs (transform.localRotation.eulerAngles.y - euler1) % 360;
		} else {
			transform.localRotation = Quaternion.Euler(0, rotateTowards(transform.eulerAngles.y, 0, rotation_speed), 0);
		}



		if (!restrictRotation) {
			transform.localRotation = Quaternion.Euler (0, transform.localRotation.eulerAngles.y, 0);
		} else {
			float angle = transform.localRotation.eulerAngles.y;

			if(angle < beginDegree && angle > endDegree){
				if(beginDegree - angle < angle - endDegree){
					angle = beginDegree;
				}
				else{
					angle = endDegree;
				}
			}

			transform.localRotation = Quaternion.Euler (0, angle, 0);
		}


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

	public float getDeltaRotation()	{
		return delta_rotation;
	}
}
