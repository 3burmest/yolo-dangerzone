using UnityEngine;
using System.Collections;

public class CreatePortalOnDestroy : MonoBehaviour {

	public GameObject _portal;

	private bool quit = false;

	void OnCollisionEnter(Collision c) {
		Debug.Log("Collision motherfuckers");
//		Destroy(gameObject);
	}

	void OnApplicationQuit() {
		quit = true;
	}

	void OnDestroy(){
		if(!quit) Instantiate(_portal, transform.position, Quaternion.identity);
	}
}
