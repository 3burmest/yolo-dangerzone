using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BattleControllerScript : MonoBehaviour {

	public Transform ShipSpawnpoint;
	public GameObject enemyShip;
	public GameObject Shield;

	List<GameObject> currentEnemies;

	Slider healthSlider;
	Slider shieldSlider;

	int enemiesLeft = 5;
	int activeEnemies = 3;
	int enemiesAddedPerBattle = 3;
	float spawnDelay = 1;
	float nextSpawn;

	// Use this for initialization
	void Start () {
		currentEnemies = new List<GameObject> ();
		nextSpawn = Time.fixedTime;

		int battleNumber = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControllerScript> ().getBattleNumber ();
		int bonus = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControllerScript> ().bonusEnemiesKilled ();
		Debug.Log (bonus + "bonus");
		enemiesLeft += battleNumber * enemiesAddedPerBattle;
		enemiesLeft -= bonus;
		enemiesLeft = enemiesLeft < 0 ? 0 : enemiesLeft;

		activeEnemies += battleNumber;

		shieldSlider = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControllerScript> ().getEnemyShieldSlider ();
		healthSlider = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControllerScript> ().getEnemyHPSlider ();

		shieldSlider.maxValue = enemiesLeft;
		shieldSlider.value = enemiesLeft;

		healthSlider.maxValue = enemiesLeft * 100;
		healthSlider.value = enemiesLeft * 100;
	}
	
	// Update is called once per frame
	void Update () {
		currentEnemies.RemoveAll(i => i == null);
		int newEnemies = activeEnemies - currentEnemies.Count;
		newEnemies = newEnemies > enemiesLeft ? enemiesLeft : newEnemies;

		shieldSlider.value = enemiesLeft + currentEnemies.Count;
		if (shieldSlider.value == 0) {
			Destroy(Shield.gameObject);
		}

		for (int i = 0; i < newEnemies; i++) {
			if(Time.fixedTime < nextSpawn){
				break;
			}
			nextSpawn = Time.fixedTime + spawnDelay;
			GameObject a = (GameObject) Instantiate(enemyShip, ShipSpawnpoint.position, ShipSpawnpoint.rotation);
			a.GetComponent<Rigidbody>().AddForce(ShipSpawnpoint.forward * 100, ForceMode.Impulse);
			currentEnemies.Add(a);
			enemiesLeft--;
		}
	}
}
