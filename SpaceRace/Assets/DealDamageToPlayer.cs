using UnityEngine;
using System.Collections;

public class DealDamageToPlayer : MonoBehaviour {

	public float damage;
	public float damageSpread; // Zufällige Abweichung

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Player") {
			StatsScript stats = other.gameObject.GetComponent<StatsScript>();
			stats.dealDamage(damage + Random.Range(damage - damageSpread, damage + damageSpread));
			Destroy(gameObject);
		}
		                       

	}
}
