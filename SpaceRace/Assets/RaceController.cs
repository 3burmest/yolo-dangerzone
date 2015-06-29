using UnityEngine;
using UnityEngine.UI;
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

	public Text timerText; 

	List<GameObject> generatedCheckpoints;
	int currentCheckpoint;
	float startTime;

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
		startTime = Time.fixedTime;
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

		float currentTime = Time.fixedTime - startTime;
		timerText.text = toMinSecMilString (currentTime);
	}

	string toMinSecMilString(float time){
		int sec = Mathf.RoundToInt(time - 0.5f);
		int min = sec / 60;
		sec %= 60;
		int mil = (int) ((time % 1) * 1000);

		string minString = "" + min;
		if (min < 10)
			minString = "0" + minString;

		string secString = "" + sec;
		if (sec < 10)
			secString = "0" + secString;

		string milString = "" + mil;
		if (mil < 100)
			milString = "0" + milString;
		if (mil < 10)
			milString = "0" + milString;

		string timeString = minString + ":" + secString + "." + milString;
		return timeString;

	}
}
