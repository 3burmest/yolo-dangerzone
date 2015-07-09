using UnityEngine;
using System.Collections;

public class GunTarget : MonoBehaviour {

	[Range(0.0f, 1.0f)]
	public float boundarySize;

	public float distance;

	// Raumschiff
	public GameObject origin;

	// Use this for initialization
	void Start () {
//		Cursor.visible = false;

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetVector = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);

		Vector2 center = new Vector2 (Screen.width / 2.0f, Screen.height / 2.0f);

		float newX = Mathf.Clamp (targetVector.x, center.x - center.x * boundarySize, center.x + center.x * boundarySize);
		float newY = Mathf.Clamp (targetVector.y, center.y - center.y * boundarySize, center.y + center.y * boundarySize);

		targetVector = new Vector3 (newX, newY, 0);

		Debug.Log (targetVector);
		Ray ray = Camera.main.ScreenPointToRay(targetVector);
//		ray.origin = origin.transform.position;
		Debug.DrawRay (ray.origin, ray.direction * distance, Color.yellow);
		Debug.DrawLine (ray.origin, ray.origin + ray.direction * distance);
		transform.position = ray.origin + ray.direction * distance;
	}

}
