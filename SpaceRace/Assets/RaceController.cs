using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaceController : MonoBehaviour {

	public int numberOfCheckpoints;
	public int distanceBetweenCheckpoints;
	public float distanceFromPlanet;

	[Range(0.0f, 360.0f)]
	public float firstCheckpointRadians;

	public GameObject checkpoint;
	public GameObject center;

	List<GameObject> generatedCheckpoints;
	int currentCheckpoint;

	// Use this for initialization
	void Start () {
		generatedCheckpoints = new List<GameObject> ();
		createCheckpoints ();
	}

	void createCheckpoints(){
		currentCheckpoint = 0;
		for (int i = 0; i < numberOfCheckpoints; i++) {
			
			float pos = (firstCheckpointRadians - distanceBetweenCheckpoints * i) * Mathf.Deg2Rad;
			pos = pos > 2 * Mathf.PI ? pos - 2 * Mathf.PI : pos;

			float radius = distanceFromPlanet;
			Debug.Log(radius);
			Vector3 location = center.transform.position + new Vector3 (Mathf.Sin(pos) * radius, 0, Mathf.Cos(pos) * radius);

			GameObject a = (GameObject) Instantiate(checkpoint, location, checkpoint.transform.rotation);
//			a.SetActive(false);
			generatedCheckpoints.Add(a);
		}

		generatedCheckpoints [currentCheckpoint].SetActive (true);
	}

	public void nextCheckpoint(){
		generatedCheckpoints [currentCheckpoint++].SetActive (false);

		if (currentCheckpoint == numberOfCheckpoints) {
			//TODO Portal Spawnen als letzten Checkpoint!
			Debug.Log("Alle Checkpoints abgefahren");
		} else {
			generatedCheckpoints [currentCheckpoint].SetActive (true);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
