using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleControllerScript : MonoBehaviour {

	public Transform ShipSpawnpoint;
	public GameObject enemyShip;

	List<GameObject> currentEnemies;

	int enemiesLeft = 9;
	int activeEnemies = 3;
	float spawnDelay = 2;
	float nextSpawn;

	// Use this for initialization
	void Start () {
		currentEnemies = new List<GameObject> ();
		nextSpawn = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
		currentEnemies.RemoveAll(i => i == null);
		int newEnemies = activeEnemies - currentEnemies.Count;
		Debug.Log (newEnemies);
		Debug.Log (currentEnemies.Count + "cur");

		for (int i = 0; i < newEnemies; i++) {
			Debug.Log(i + " " + Time.fixedTime + " " + nextSpawn);
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
