using UnityEngine;
using System.Collections;

public class ExplodeOnEnemy : MonoBehaviour {

	public GameObject explosion;
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Enemy") {
			Instantiate (explosion, col.gameObject.transform.position, Quaternion.identity);

			Destroy (col.gameObject);
			Destroy (gameObject);
		} else {
			Instantiate(explosion, col.gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}

	}
}
