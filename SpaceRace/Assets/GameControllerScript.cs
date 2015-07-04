using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

	public GameObject FirstPersonCamera;
	public GameObject ThirdPersonCamera;
	public GameObject CockpitHUDGui;
	public GameObject PlayerShip;
	public GameObject PauseMenu;

	bool thirdPersonIsOn = false;
	bool pauseMenu = false;

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

		if (Input.GetKeyDown("p")) {
			PauseContinue();
		}
	}

	public void PauseContinue() {
		if(pauseMenu) {
				PauseMenu.SetActive(false);
				Time.timeScale = 1.0F;
				pauseMenu = false;
			} else {
				PauseMenu.SetActive(true);
				Time.timeScale = 0.0F;
				pauseMenu = true;
			}
	}

	public void ContinueButtonClick() {
		Debug.Log("Continue");
	}
}
