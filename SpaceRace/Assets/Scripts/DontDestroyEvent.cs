using UnityEngine;
using System.Collections;

public class DontDestroyEvent : MonoBehaviour {

	void Awake() {
		Object.DontDestroyOnLoad(gameObject);
		if (FindObjectsOfType(GetType()).Length > 1) {
			Destroy(gameObject);
		}
	}
}
