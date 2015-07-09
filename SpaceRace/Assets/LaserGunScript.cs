using UnityEngine;
using System.Collections;

public class LaserGunScript : MonoBehaviour {

	public GameObject bolt;
	public GameObject target;
	public float Feuerrate;
	public float initialDelay = 0;


	float nextFire;

	// Use this for initialization
	void Start () {
		nextFire = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			nextFire = Time.fixedTime + initialDelay;
		}

		if (Input.GetKey(KeyCode.Space)|| Input.GetMouseButton(0)) {
			if(Time.fixedTime >= nextFire){
				GameObject clone = (GameObject) Instantiate(bolt, transform.position, transform.rotation);
				clone.transform.LookAt(target.transform.position);
				clone.transform.TransformDirection(Vector3.forward * 10);
				nextFire = Time.fixedTime + Feuerrate;
			}
		}
	}
}
