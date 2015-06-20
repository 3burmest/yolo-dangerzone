using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GenerateOrbit2 : MonoBehaviour {
	
	public GameObject[] asteroids;
	public int numberOfAsteroids;
	
	//Entfernung des Gürtels vom Planeten
	public float distanceFromPlanet;
	
	//Dicke des Gürtels
	public float spread;

	public float asteroidSizeFactor;
	
	List<GameObject> generatedAstroids;
	
	
	// Use this for initialization
	void Start () {
		generatedAstroids = new List<GameObject> ();
		
		for (int i = 0; i < numberOfAsteroids; i++) {
			//			GameObject o = asteroids[Random.Range(0, asteroids.Length)];
			GameObject o = asteroids[0];
			
			Vector2 offset = Random.insideUnitCircle.normalized * distanceFromPlanet;
			Vector3 location = transform.position + new Vector3(offset.x, 0, offset.y);
			location += Random.insideUnitSphere * spread;
			
			generatedAstroids.Add((GameObject) Instantiate(o, location, Quaternion.identity));
		}
		
		foreach (GameObject a in generatedAstroids) {
			a.GetComponent<Rigidbody>().AddForce(Vector3.Cross(transform.position - a.transform.position, Vector3.up), ForceMode.Impulse);
			a.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
			a.GetComponent<Rigidbody>().angularVelocity = (Random.insideUnitSphere * 1);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject a in generatedAstroids) {
			Vector3 dir = transform.position - a.transform.position;
			
			a.GetComponent<Rigidbody>().AddForce(dir.normalized * Vector3.Distance(transform.position, a.transform.position), ForceMode.Force);
		}
	}
}
