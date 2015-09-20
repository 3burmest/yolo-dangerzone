using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "Bullet" || c.tag == "Rocket") {
			Destroy(c.gameObject);
		}
	}
}
