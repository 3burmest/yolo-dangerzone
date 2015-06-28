using UnityEngine;
using System.Collections;

public class AsteroidDestruction : MonoBehaviour {

	public float maxHP = 100f;
	public GameObject explosion;
	float HP;

	// Use this for initialization
	void Start () {
		HP = maxHP;
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.tag == "Bullet" || other.tag == "Asteroid" || other.tag == "Player")
		{

			if (other.tag == "Player") {
				StatsScript stats = other.GetComponent<StatsScript>();
				stats.dealDamage(75);
				HP = 0;
			}
			else
			{
				HP -= 35;
				Destroy(other.gameObject);
			}


			if (HP <= 0 || other.tag == "Asteroid") {
				if (explosion != null && Time.fixedTime > 1)
				{
					if(transform.lossyScale.magnitude > 20 && transform.GetChild(0).tag != "Powerup"){
						// Split to make new Asteroids if size is big enough
						GameObject a1 = (GameObject) Instantiate(gameObject, transform.position + Random.onUnitSphere * 50, transform.rotation);
						a1.transform.localScale = Vector3.one * (transform.lossyScale.x / 3.0f);
						a1.GetComponent<Rigidbody>().angularVelocity = (Random.insideUnitSphere * 1) * 5;

						GameObject a2 = (GameObject) Instantiate(gameObject, transform.position + Random.onUnitSphere * 50, transform.rotation);
						a2.transform.localScale = Vector3.one * (transform.lossyScale.x / 3.0f);
						a2.GetComponent<Rigidbody>().angularVelocity = (Random.insideUnitSphere * 1) * 5;
//						Instantiate(gameObject, transform.position, transform.rotation);
					}
					else if(transform.GetChild(0).tag == "Powerup"){
						StatsScript stats = GameObject.FindGameObjectWithTag("Player").GetComponent<StatsScript>();
						stats.addGold((int) transform.lossyScale.magnitude);
					}
			
					Instantiate(explosion, transform.position, transform.rotation);
				}
				
				Destroy(gameObject);
			}
		}

		if (other.tag == "Player") {
			StatsScript health = other.GetComponent<StatsScript>();
			health.dealDamage(75);
		}

	}
}
