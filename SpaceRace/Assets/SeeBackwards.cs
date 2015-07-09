using UnityEngine;
using System.Collections;

public class SeeBackwards : MonoBehaviour {
	public GameObject cockpitHUD;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(Input.GetKeyDown(KeyCode.LeftShift)) {
			transform.rotation = Quaternion.LookRotation(-transform.parent.transform.forward, transform.parent.transform.up);
			transform.position = transform.position - 10*transform.parent.transform.forward;
			cockpitHUD.SetActive(false);
		}

		if(Input.GetKeyUp(KeyCode.LeftShift)){
			transform.rotation = Quaternion.LookRotation(transform.parent.transform.forward, transform.parent.transform.up);
			transform.position = transform.position + 10*transform.parent.transform.forward;
			cockpitHUD.SetActive(true);
		}
	}
}
