using UnityEngine;
using System.Collections;

public class TurretGunScript : MonoBehaviour {

	public float rotation_speed;
	public Transform gunpoint1, gunpoint2;
	public GameObject laserShot;
	public float engage_min_angle; // Wie genau die Ausrichtung der Gun sein muss um zu Schießen
	public float feuerrate;
	public float spread;

	// Rotation
	private float rotation_x;
	private float delta_rotation = 0;

	private GameObject currentTarget;

	private float max_x = 280;
	private float min_x = 25;

	// Shooting
	private int fireStatus = 0;
	/**
	 * 0 = idle
	 * 1 = following
	 * 2 = firing
	 */

	private float nextFire = 0f;
	private int gun = 0; // um abwechselnd zu Schießen

	// Target
	private string targetTag; 

	// Use this for initialization
	void Start () {
		rotation_x = transform.localRotation.eulerAngles.x;
		targetTag = transform.parent.parent.GetComponent<TargetScript> ().target;
	}
	
	// Update is called once per frame
	void Update () {

		findTarget ();

		if (currentTarget != null) {
			
			Vector3 targetVector = currentTarget.transform.position - transform.position;
			
			Quaternion targetRotation = Quaternion.LookRotation (targetVector, transform.forward);

			Debug.DrawRay (transform.position, transform.forward * 1000, Color.blue);
			
			transform.rotation = targetRotation;

			float gun_delta_rotation = Mathf.Abs (transform.localRotation.eulerAngles.x - rotation_x);
			float top_delta_rotation = transform.parent.GetComponent<TurretTopScript> ().getDeltaRotation ();

			delta_rotation = Mathf.Sqrt (Mathf.Pow (gun_delta_rotation, 2) + Mathf.Pow (top_delta_rotation, 2));

			if(fireStatus < 2 && delta_rotation < 0.5f){
				fireStatus = 2;
			}
			else {
				fireStatus = 1;
			}

		} else {
			fireStatus = 0;
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}

		rotation_x = rotateTowards (rotation_x, transform.localRotation.eulerAngles.x, rotation_speed);

		if (rotation_x > min_x && rotation_x < max_x) {
			if(rotation_x - min_x < max_x - rotation_x){
				rotation_x = min_x;
			}
			else{
				rotation_x = max_x;
			}
		}

		transform.localRotation = Quaternion.Euler (rotation_x, 0, 0);

		if (fireStatus == 2) {
			if(Time.fixedTime >= nextFire){
				GameObject clone;

				float rx = Random.Range(-spread, spread);
				float ry = Random.Range(-spread, spread);
				float rz = Random.Range(-spread, spread);

				if(gun++ % 2 == 0){
					clone = (GameObject) Instantiate(laserShot, gunpoint1.position, gunpoint1.rotation);
				}else{
					clone = (GameObject) Instantiate(laserShot, gunpoint2.position, gunpoint2.rotation);
				}

				clone.transform.Rotate(rx, ry, rz);
				nextFire = Time.fixedTime + feuerrate;
			}
		}

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
