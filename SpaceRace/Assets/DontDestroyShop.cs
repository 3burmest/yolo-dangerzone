using UnityEngine;
using System.Collections;

public class DontDestroyShop : MonoBehaviour {

	void Awake() {
		Object.DontDestroyOnLoad(gameObject);
		if (FindObjectsOfType(GetType()).Length > 1) {
			Destroy(gameObject);
		}
	}
}
