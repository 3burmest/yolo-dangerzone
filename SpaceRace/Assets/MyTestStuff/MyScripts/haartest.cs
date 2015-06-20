using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class haartest : MonoBehaviour {

	public GameObject Haar;
	public int amount = 1;
	List<GameObject> haare = new List<GameObject>();

	void Start () {
		for (int i = 0; i < amount; i++) {
			GameObject o = (GameObject) Instantiate(Haar, transform.position, transform.rotation);
			haare.Add(o);
			o.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
		}
	}


	void FixedUpdate () {
	
		foreach (GameObject o in haare) {
			Debug.Log(o);
		}

	}
}
