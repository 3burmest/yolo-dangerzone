using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RaceController : MonoBehaviour {

	public int numberOfCheckpoints;
	public int distanceBetweenCheckpoints;
	public float spread;
	public float distanceFromPlanet;

	[Range(0.0f, 360.0f)]
	public float firstCheckpointRadians;

	// Zeit Eigenschaften
	public float startingSeconds;
	public float secondsGainedPerCheckpoint;

	public GameObject checkpoint;
	public GameObject center;
	public GameObject portal;

	public Text timerText; 

	List<GameObject> generatedCheckpoints;
	int currentCheckpoint;
	float lastTime;
	float timeLeft;

	// Use this for initialization
	void Start () {
		generatedCheckpoints = new List<GameObject> ();
		createCheckpoints ();
	}

	void createCheckpoints(){
		currentCheckpoint = 0;
		for (int i = 0; i <= numberOfCheckpoints; i++) {
			
			float pos = (firstCheckpointRadians - distanceBetweenCheckpoints * i) * Mathf.Deg2Rad;
			pos = pos > 2 * Mathf.PI ? pos - 2 * Mathf.PI : pos;

			float radius = distanceFromPlanet;
			Vector3 location = center.transform.position + new Vector3 (Mathf.Sin(pos) * radius, 0, Mathf.Cos(pos) * radius);
			location += Random.insideUnitSphere * spread;


			GameObject a;

			if(i == numberOfCheckpoints){
				a = (GameObject) Instantiate(portal, location, checkpoint.transform.rotation);
			} else {
				a = (GameObject) Instantiate(checkpoint, location, checkpoint.transform.rotation);
			}
			a.SetActive(false);
			generatedCheckpoints.Add(a);
		}

		generatedCheckpoints [currentCheckpoint].SetActive (true);

		timeLeft = startingSeconds;
	}

	public void nextCheckpoint(){
		generatedCheckpoints [currentCheckpoint++].SetActive (false);
		timeLeft += secondsGainedPerCheckpoint;

		if (currentCheckpoint == numberOfCheckpoints) {
			generatedCheckpoints [currentCheckpoint].SetActive (true);
			Debug.Log("Alle Checkpoints abgefahren");
		} else {
			generatedCheckpoints [currentCheckpoint].SetActive (true);
		}

	}
	
	// Update is called once per frame
	void Update () {
		float passedTime = Time.fixedTime - lastTime;
		lastTime = Time.fixedTime;
		timeLeft -= passedTime;
		timerText.text = toMinSecMilString (timeLeft);
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
