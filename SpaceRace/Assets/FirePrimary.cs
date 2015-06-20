using UnityEngine;
using System.Collections;

public class FirePrimary : MonoBehaviour {

	public GameObject shot;
	public float fireSpeed = 1f;

	private float nextFire;

	// Use this for initialization
	void Start () {
		nextFire = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Mouse0)){
			if(Time.fixedTime > nextFire){
				GameObject s = (GameObject) Instantiate(shot, transform.position, transform.rotation);
				nextFire = Time.fixedTime + fireSpeed;
			}
		}
	}
}
