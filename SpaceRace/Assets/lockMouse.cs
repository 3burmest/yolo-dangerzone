using UnityEngine;
using System.Collections;

public class lockMouse : MonoBehaviour {

	bool lockCursor = false;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			lockCursor = !lockCursor;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
