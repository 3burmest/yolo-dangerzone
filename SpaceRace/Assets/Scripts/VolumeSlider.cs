using UnityEngine;
using System.Collections;

public class VolumeSlider : MonoBehaviour {

	void Start(){
		AudioListener.volume = 0.05f;
	}

	public void OnValueChanged(float val) {
		Debug.Log ("hi");
		AudioListener.volume = val;
	}
}
