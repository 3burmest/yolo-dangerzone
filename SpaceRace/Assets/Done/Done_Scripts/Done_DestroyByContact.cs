using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public int maxHealth;

	private int health;

	private Done_GameController gameController;



	void Start ()
	{
		health = maxHealth;
		GameObject gameControllerObject = GameObject.FindGameObjectsWithTag ("GameController")[0];
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (other.tag == "Rocket") {
			other.transform.parent.GetChild(1).GetComponent<ParticleSystem>().Stop();
			other.transform.parent.GetChild(1).parent = null;
			Destroy(other.transform.parent.gameObject);
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
		Debug.Log (other.name);
		if (other.tag == "Bullet" && other.name != "LaserGreen")
		{
			health -= 15;
			if(health <= 0){
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy (gameObject);
				Destroy(other.transform.gameObject);
			}
		}

		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
//			gameController.GameOver();
		}
		
//		gameController.AddScore(scoreValue);
//		Destroy (other.gameObject);
//		Destroy (gameObject);
	}
}