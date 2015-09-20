using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	public string startLevel = "AsteroidenOrbit";

	public void LoadNewLevel() {
		Application.LoadLevel(startLevel);
	}
}
