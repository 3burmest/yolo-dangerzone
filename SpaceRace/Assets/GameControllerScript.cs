using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

	public GameObject FirstPersonCamera;
	public GameObject ThirdPersonCamera;
	public GameObject CockpitHUDGui;
	public GameObject PlayerShip;
	public GameObject PauseMenu;
	public GameObject ShopMenu;

	public GameObject EnemyShield;
	public GameObject EnemyHP;

	public bool startWithPause = false;

	bool thirdPersonIsOn = false;
	bool pauseMenu = false;

	int raceNumber = 0;
	int battleNumber = 0;
	float timeLeftFromRace = 0;

	// Use this for initialization
	void Start () {
		if(startWithPause) {
			PauseContinue();
		}
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
				ShopMenu.SetActive(false);
				Time.timeScale = 1.0F;
				pauseMenu = false;
				Screen.lockCursor = true;
			} else {
				PauseMenu.SetActive(true);
				Time.timeScale = 0.0F;
				pauseMenu = true;
				Screen.lockCursor = false;
			}
	}

	public void showShop(){
		PauseMenu.SetActive (false);
		ShopMenu.SetActive (true);
	}

	public void hideShop(){
		PauseMenu.SetActive (true);
		ShopMenu.SetActive (false);
	}

	public void ContinueButtonClick() {
		Debug.Log("Continue");
	}

	public int getRaceNumber(){
		return raceNumber++;
	}

	public int getBattleNumber(){
		return battleNumber++;
	}

	public void setTimeLeftFromRace(float t){
		timeLeftFromRace = t;
	}

	public int bonusEnemiesKilled(){
		return (int) timeLeftFromRace / 10;
	}

	public void hideEnemyBars(){
		EnemyShield.SetActive (false);
		EnemyHP.SetActive (false);
	}

	public Slider getEnemyShieldSlider(){
		EnemyShield.SetActive (true);
		return EnemyShield.transform.GetChild(0).GetComponent<Slider>();
	}

	public Slider getEnemyHPSlider(){
		EnemyHP.SetActive (true);
		return EnemyHP.transform.GetChild(0).GetComponent<Slider>();
	}

}
