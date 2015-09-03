using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopScript : MonoBehaviour {

	public GameObject RaketenKaufButton;
	public GameObject FeuerrateKaufButton;

	private int RaketenKaufPreis = 100;
	private int FeuerrateKaufPreis = 200;

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
}
