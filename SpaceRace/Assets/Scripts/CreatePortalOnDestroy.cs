using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreatePortalOnDestroy : MonoBehaviour {

	public GameObject _portal;

	public GameObject explosion;

	private bool quit = false;

	Slider healthbar;

	void Start(){
		healthbar = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControllerScript> ().getEnemyHPSlider();
	}

	void OnCollisionEnter(Collision c) {

		if (c.gameObject.tag == "Bullet") {
			healthbar.value -= 40;
			if(healthbar.value <= 0){
				GameObject e = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
				e.transform.localScale += new Vector3(1, 1, 1);
				Destroy(gameObject);
			}
		}
	}

	void OnApplicationQuit() {
		quit = true;
	}

	void OnDestroy(){
		if(!quit) Instantiate(_portal, transform.position, Quaternion.identity);
	}
}
