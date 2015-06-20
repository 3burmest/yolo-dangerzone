using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GenerateOrbit : MonoBehaviour {

	// Asteoriden zum generieren
	public GameObject[] asteroids;

	// Anzahl der zu generierenden Asteoriden
	public int numberOfAsteroids;

	// Entfernung des Gürtels vom Planeten
	public float distanceFromPlanet;

	// Dicke des Gürtels
	public float spread;

	// Größenmultiplikator der Asteoriden
	public float asteroidSizeFactor;

	// Geschwindigkeit der Asteoriden im Orbit
	public float rotationSpeed;

	// Geschwindigkeit der Rotation um die eigene Achse der Asteoriden
	public float eigenRotGeschwindigkeit;

	// Anfang und Ende von generierten Asteoriden (Performanzgründe)
	[Range(0.0f, 360.0f)]
	public float beginDegree;

	[Range(0.0f, 360.0f)]
	public float endDegree;

	List<GameObject> generatedAstroids;

	void OnValidate()
	{
		endDegree = Mathf.Clamp (endDegree, beginDegree, 360.0f);
	}

	// Init
	void Start () {
		generatedAstroids = new List<GameObject> ();

		for (int i = 0; i < numberOfAsteroids; i++) {
			GameObject o = asteroids[Random.Range(0, asteroids.Length)];
			
			// Da um nicht alle am selben Fleck zu generieren und zur Verteilung
			Vector2 offset = Random.insideUnitCircle.normalized * distanceFromPlanet;
			Vector3 location = transform.position + new Vector3(offset.x, 0, offset.y);
			location += Random.insideUnitSphere * spread;

			float pos = Random.Range(beginDegree * Mathf.Deg2Rad, endDegree*Mathf.Deg2Rad);
			float radius = Vector3.Distance (location, transform.position);
			location = transform.position + new Vector3 (Mathf.Sin(pos) * radius, location.y, Mathf.Cos(pos) * radius);

			GameObject a = (GameObject) Instantiate(o, location, Quaternion.identity);

			// Größe verändern
			a.transform.localScale = Vector3.one * asteroidSizeFactor;
			
			// Eigenrotation;
			a.GetComponent<Rigidbody>().angularVelocity = (Random.insideUnitSphere * 1) * eigenRotGeschwindigkeit;
			
			// Orbit Script dem Asteorieden hinzufügen
			a.AddComponent<Orbit>();
			
			// Rotationsmittelpunkt (Planet)
			a.GetComponent<Orbit>().target = transform;
			
			// Festlegen der Position im Orbit
			a.GetComponent<Orbit>().pos = pos;
			
			// Übergabe der Geschwindigkeit
			a.GetComponent<Orbit>().speed = rotationSpeed;
			
			// Ort der Zerstörung
			a.GetComponent<Orbit>().destroyRad = endDegree * Mathf.Deg2Rad;
			
			// Dem Planeten unterordnen
			a.transform.parent = transform;

			generatedAstroids.Add(a);
		}

	}
	
	// Update is called once per frame
	void Update () {

		generatedAstroids.RemoveAll(i => i == null);

		int newAstroids = numberOfAsteroids - generatedAstroids.Count;

		List<GameObject> newGeneratedAstroids = new List<GameObject>();

		for (int i = 0; i < newAstroids; i++) {
			GameObject o = asteroids[Random.Range(0, asteroids.Length)];
			
			// Da um nicht alle am selben Fleck zu generieren und zur Verteilung
			Vector2 offset = Random.insideUnitCircle.normalized * distanceFromPlanet;
			Vector3 location = transform.position + new Vector3(offset.x, 0, offset.y);
			location += Random.insideUnitSphere * spread;
			
			float pos = beginDegree * Mathf.Deg2Rad;
			float radius = Vector3.Distance (location, transform.position);
			location = transform.position + new Vector3 (Mathf.Sin(pos) * radius, location.y, Mathf.Cos(pos) * radius);
			
			GameObject a = (GameObject) Instantiate(o, location, Quaternion.identity);
			
			// Größe verändern
			a.transform.localScale = Vector3.one * asteroidSizeFactor;
			
			// Eigenrotation;
			a.GetComponent<Rigidbody>().angularVelocity = (Random.insideUnitSphere * 1) * eigenRotGeschwindigkeit;
			
			// Orbit Script dem Asteorieden hinzufügen
			a.AddComponent<Orbit>();
			
			// Rotationsmittelpunkt (Planet)
			a.GetComponent<Orbit>().target = transform;
			
			// Festlegen der Position im Orbit
			a.GetComponent<Orbit>().pos = pos;
			
			// Übergabe der Geschwindigkeit
			a.GetComponent<Orbit>().speed = rotationSpeed;
			
			// Ort der Zerstörung
			a.GetComponent<Orbit>().destroyRad = endDegree * Mathf.Deg2Rad;
			
			// Dem Planeten unterordnen
			a.transform.parent = transform;
			
			generatedAstroids.Add(a);
		}

		addListToList(newGeneratedAstroids, generatedAstroids);

	}

	public static void addListToList(List<GameObject> source, List<GameObject> target)
	{
		foreach (GameObject a in source) {
			target.Add(a);
		}
	}
}
