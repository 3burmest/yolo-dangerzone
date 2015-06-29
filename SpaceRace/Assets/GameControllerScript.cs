using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {

	public GameObject FirstPersonCamera;
	public GameObject ThirdPersonCamera;
	public GameObject CockpitHUDGui;
	public GameObject PlayerShip;

	bool thirdPersonIsOn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.C)) {
			if(thirdPersonIsOn){
				FirstPersonCamera.SetActive(true);
				CockpitHUDGui.SetActive(true);
				ThirdPersonCamera.SetActive(false);

				thirdPersonIsOn = false;
			}
			else{
				FirstPersonCamera.SetActive(false);
				CockpitHUDGui.SetActive(false);
				ThirdPersonCamera.SetActive(true);
				ThirdPersonCamera.transform.position = PlayerShip.transform.position;
				ThirdPersonCamera.transform.rotation = PlayerShip.transform.rotation;

				thirdPersonIsOn = true;
			}
		}
	
	}
}
