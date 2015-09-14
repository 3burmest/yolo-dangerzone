using UnityEngine;
using System.Collections;

public class VolumeSlider : MonoBehaviour {

	public void OnValueChanged(float val) {
		AudioListener.volume = val;
	}
}
