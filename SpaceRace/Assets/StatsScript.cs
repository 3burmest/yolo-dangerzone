using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Für alle variablen Werte (Leben, Schild, Gold, Punkte)

public class StatsScript : MonoBehaviour {

	public Text goldText;

	public float maxHealth;
	public float maxShield;
	public float maxNitro;

	public Slider healthSlider;
	public Slider shieldSlider;
	public Slider nitroSlider;

	public float shieldRechargeDelay;
	public float shieldRechargeSpeed;
	public float nitroRechargeSpeed;

	public int nitroSpeed = 350;

	float lastDamageTime = 0;

	float health;
	float shield;
	int gold;
	float nitro;

	bool nitroUsed = false;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {

		health = maxHealth;
		shield = maxShield;
		nitro = maxNitro;

		healthSlider.maxValue = maxHealth;
		shieldSlider.maxValue = maxShield;
		nitroSlider.maxValue = maxNitro;

		gold = 1000;
	}

	public void addGold(int g){
		gold += g;
	}

	public int getGold(){
		return gold;
	}

	public void removeGold(int g){
		gold -= g;
		Update ();
	}

	public float missingHealth(){
		return maxHealth - health;
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

		shieldSlider.maxValue = maxShield;
	
		healthSlider.value = health;
		shieldSlider.value = shield;
		nitroSlider.value = nitro;

		goldText.text = "" + gold;
//		goldText.text = "Hallo";

		if (Input.GetKeyDown(KeyCode.LeftAlt) && !nitroUsed && nitro >= maxNitro) {
			gameObject.GetComponent<ShipControl>().speed = nitroSpeed;
			nitroUsed = true;
		} else if (nitroUsed && nitro > 0) {
			nitro -= 1.0F;
		} else if (nitro < maxNitro) {
			gameObject.GetComponent<ShipControl>().speed = 50;
			nitroUsed = false;
			nitro += nitroRechargeSpeed;
		}
	}
}
