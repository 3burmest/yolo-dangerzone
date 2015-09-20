using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopScript : MonoBehaviour {

	public GameObject RaketenKaufButton;
	public GameObject FeuerrateKaufButton;
	public GameObject LebenKaufButton;
	public GameObject LebenRechargeKaufButton;
	public GameObject SchildRechargeRateKaufButton;
	public GameObject SchildCapacityKaufButton;
	public GameObject SchildRechargeDelayKaufButton;
	public GameObject NitroRechargeRateKaufButton;
	public GameObject NitroCapacityKaufButton;

	private int RaketenKaufPreis = 100;
	private int FeuerrateKaufPreis = 150;
	private int LebenKaufPreis = 125;
	private int LebenRechargeKaufPreis = 100;
	private int SchildRechargeRateKaufPreis = 225;
	private int SchildCapacityKaufPreis = 200;
	private int SchildRechargeDelayKaufPreis = 250;
	private int NitroRechargeRateKaufPreis = 200;
	private int NitroCapacityKaufPreis = 200;

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (player.GetComponent<RocketTargeting> ().missingRockets() > 0 && player.GetComponent<StatsScript>().getGold() >= RaketenKaufPreis) {
			RaketenKaufButton.GetComponent<Button> ().interactable = true;
		} else {
			RaketenKaufButton.GetComponent<Button> ().interactable = false;
		}

		if (player.GetComponent<StatsScript>().getGold() >= FeuerrateKaufPreis) {
			FeuerrateKaufButton.GetComponent<Button> ().interactable = true;
		} else {
			FeuerrateKaufButton.GetComponent<Button> ().interactable = false;
		}

		if (player.GetComponent<StatsScript>().getGold() >= LebenKaufPreis) {
			LebenKaufButton.GetComponent<Button> ().interactable = true;
		} else {
			LebenKaufButton.GetComponent<Button> ().interactable = false;
		}

		if (player.GetComponent<StatsScript>().missingHealth() >= 1 && player.GetComponent<StatsScript>().getGold() >= LebenRechargeKaufPreis) {
			LebenRechargeKaufButton.GetComponent<Button> ().interactable = true;
		} else {
			LebenRechargeKaufButton.GetComponent<Button> ().interactable = false;
		}

		if (player.GetComponent<StatsScript>().getGold() >= SchildRechargeRateKaufPreis) {
			SchildRechargeRateKaufButton.GetComponent<Button> ().interactable = true;
		} else {
			SchildRechargeRateKaufButton.GetComponent<Button> ().interactable = false;
		}

		if (player.GetComponent<StatsScript>().getGold() >= SchildCapacityKaufPreis) {
			SchildCapacityKaufButton.GetComponent<Button> ().interactable = true;
		} else {
			SchildCapacityKaufButton.GetComponent<Button> ().interactable = false;
		}

		if (player.GetComponent<StatsScript>().getGold() >= SchildRechargeDelayKaufPreis) {
			SchildRechargeDelayKaufButton.GetComponent<Button> ().interactable = true;
		} else {
			SchildRechargeDelayKaufButton.GetComponent<Button> ().interactable = false;
		}

		if (player.GetComponent<StatsScript>().getGold() >= NitroRechargeRateKaufPreis) {
			NitroRechargeRateKaufButton.GetComponent<Button> ().interactable = true;
		} else {
			NitroRechargeRateKaufButton.GetComponent<Button> ().interactable = false;
		}

		if (player.GetComponent<StatsScript>().getGold() >= NitroCapacityKaufPreis) {
			NitroCapacityKaufButton.GetComponent<Button> ().interactable = true;
		} else {
			NitroCapacityKaufButton.GetComponent<Button> ().interactable = false;
		}

	}

	public void RaketenKauf(){
		if (player.GetComponent<RocketTargeting> ().missingRockets () > 0 && player.GetComponent<StatsScript>().getGold() >= RaketenKaufPreis) {
			player.GetComponent<StatsScript>().removeGold(RaketenKaufPreis);
			player.GetComponent<RocketTargeting>().addRocket();
		}
	}

	public void FeuerrateKauf(){
		if (player.GetComponent<StatsScript>().getGold() >= FeuerrateKaufPreis) {
			player.GetComponent<StatsScript>().removeGold(FeuerrateKaufPreis);
			foreach(GameObject o in GameObject.FindGameObjectsWithTag("PlayerGun")){
				o.GetComponent<LaserGunScript2>().increaseFirerate(0.7f);
			}
		}
	}

	public void LebenKauf(){
		if (player.GetComponent<StatsScript>().getGold() >= LebenKaufPreis) {
			player.GetComponent<StatsScript>().removeGold(LebenKaufPreis);
			player.GetComponent<StatsScript>().maxHealth += 50; 
		}
	}

	public void LebenRechargeKauf(){
		if (player.GetComponent<StatsScript>().getGold() >= LebenRechargeKaufPreis) {
			player.GetComponent<StatsScript>().removeGold(LebenRechargeKaufPreis);
			player.GetComponent<StatsScript>().healUp(); 
		}
	}

	public void SchildRechargeRateKauf(){
		if (player.GetComponent<StatsScript>().getGold() >= SchildRechargeRateKaufPreis) {
			player.GetComponent<StatsScript>().removeGold(SchildRechargeRateKaufPreis);
			player.GetComponent<StatsScript>().shieldRechargeSpeed *= 1.2f; 
		}
	}

	public void SchildCapacityKauf(){
		if (player.GetComponent<StatsScript>().getGold() >= SchildCapacityKaufPreis) {
			player.GetComponent<StatsScript>().removeGold(SchildCapacityKaufPreis);
			player.GetComponent<StatsScript>().maxShield *= 1.25f; 
		}
	}

	public void SchildRechargeDelayKauf(){
		if (player.GetComponent<StatsScript>().getGold() >= SchildRechargeDelayKaufPreis) {
			player.GetComponent<StatsScript>().removeGold(SchildRechargeDelayKaufPreis);
			player.GetComponent<StatsScript>().shieldRechargeDelay *= 0.75f; 
		}
	}

	public void NitroRechargeRateKauf(){
		if (player.GetComponent<StatsScript>().getGold() >= NitroRechargeRateKaufPreis) {
			player.GetComponent<StatsScript>().removeGold(NitroRechargeRateKaufPreis);
			player.GetComponent<StatsScript>().nitroRechargeSpeed *= 1.15f; 
		}
	}

	public void NitroCapacityKauf(){
		if (player.GetComponent<StatsScript>().getGold() >= NitroCapacityKaufPreis) {
			player.GetComponent<StatsScript>().removeGold(NitroCapacityKaufPreis);
			player.GetComponent<StatsScript>().maxNitro *= 1.15f; 
		}
	}
}
