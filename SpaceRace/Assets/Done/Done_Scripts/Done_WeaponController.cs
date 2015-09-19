using UnityEngine;
using System.Collections;

public class Done_WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	public int lifetime = 5;

	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire ()
	{
		GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
		GetComponent<AudioSource>().Play();

		Destroy(clone, lifetime);
	}
}
