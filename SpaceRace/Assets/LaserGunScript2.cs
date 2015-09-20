using UnityEngine;
using System.Collections;

public class LaserGunScript2 : MonoBehaviour {

	public GameObject bolt;
	public GameObject target;
	public float Feuerrate;

	Transform[] guns;
	int numberOfGuns;
	int nextGun;
	float nextFire;
	
	// Use this for initialization
	void Start () {
		nextFire = 0;

		numberOfGuns = transform.childCount;
		guns = new Transform[numberOfGuns];
		nextGun = 0;

		for (int i = 0; i < transform.childCount; i++) {
			guns[i] = transform.GetChild(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0) {
			return;
		}
		
//		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0)) {
//			nextFire = Time.fixedTime;
//		}
		Debug.Log (!Input.GetKeyDown(KeyCode.LeftShift));
		if ((Input.GetKey(KeyCode.Space)|| Input.GetMouseButton(0)) && !Input.GetKey(KeyCode.LeftShift)) {
			if(Time.fixedTime >= nextFire){
				GameObject clone = (GameObject) Instantiate(bolt, guns[nextGun].transform.position, guns[nextGun].transform.rotation);
				clone.transform.LookAt(target.transform.position);
				clone.transform.TransformDirection(Vector3.forward * 10);
				nextFire = Time.fixedTime + Feuerrate;
				nextGun = (nextGun + 1) % numberOfGuns;
			}
		}
	}
	
	public void increaseFirerate(float multiplier){
		Feuerrate *= multiplier;
	}
}
