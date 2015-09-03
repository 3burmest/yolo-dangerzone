using UnityEngine;
using System.Collections;

public class Hitpoints : MonoBehaviour {

	public float maxHealth;
	float health;

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	public void dealDamage(float damagePoints){

		float newHealth = health - damagePoints;
		health = newHealth > 0 ? newHealth : 0;

		Debug.Log (health);
	}

	void Update(){
		if (health == 0) {
//			Destroy(gameObject);
			Debug.Log ("Dead");
		}
	}
}
