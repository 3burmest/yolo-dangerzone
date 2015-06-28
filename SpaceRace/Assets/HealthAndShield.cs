using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthAndShield : MonoBehaviour {

	public float maxHealth;
	public float maxShield;

	public Slider healthSlider;
	public Slider shieldSlider;

	public float shieldRechargeDelay;
	public float shieldRechargeSpeed;

	float lastDamageTime = 0;

	float health;
	float shield;

	// Use this for initialization
	void Start () {

		health = maxHealth;
		shield = maxShield;

		healthSlider.maxValue = maxHealth;
		shieldSlider.maxValue = maxShield;

	}

	public void dealDamage(float damagePoints){
		lastDamageTime = Time.fixedTime;
		float newShield = shield - damagePoints;

		shield = newShield > 0 ? newShield : 0;

		if (newShield < 0) {
			float newHealth = health + newShield;
			health = newHealth > 0 ? newHealth : 0;
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (shieldRechargeDelay + lastDamageTime < Time.fixedTime) {
			float newShield = shield + shieldRechargeSpeed * Time.deltaTime;
			shield = newShield < maxShield ? newShield : maxShield;
		}
	
		healthSlider.value = health;
		shieldSlider.value = shield;

	}
}
