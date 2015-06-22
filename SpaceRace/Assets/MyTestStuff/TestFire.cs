using UnityEngine;
using System.Collections;

public class TestFire : MonoBehaviour {

	public GameObject bullet;
	public float bulletSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			GameObject go = (GameObject) Instantiate(bullet, transform.position, transform.rotation);
			go.GetComponent<Rigidbody>().AddForce(go.transform.forward * bulletSpeed);
		}
	}
}
