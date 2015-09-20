using UnityEngine;
using System.Collections;

public class DamageDealer : MonoBehaviour {

	public float damage;
	
	void OnTriggerEnter (Collider other){
		Debug.Log (other.name);
		Hitpoints hp = other.transform.parent.GetComponent<Hitpoints> ();
		Debug.Log (hp);
		if (hp != null) {
			hp.dealDamage(damage);
			Destroy(gameObject);
		}
	}
}
