using UnityEngine;
using System.Collections;

public class GunTarget : MonoBehaviour {

	[Range(0.0f, 1.0f)]
	public float boundarySize;

	public float distance;

	public bool mouseMovesShip; // Maus bewegt Schiff leicht in Zielrichtung

	public float mouseSpeed = 1.0f;

	// Raumschiff
	public GameObject origin;

	private Vector3 virtualCursor;
	private Vector3 lastCursor;

	// Use this for initialization
	void Start () {
//		Cursor.visible = false;
		virtualCursor = new Vector3 (Screen.width / 2.0f, Screen.height / 2.0f, 0);
		lastCursor = Input.mousePosition;
		Screen.lockCursor = true;
//		Cursor.lockState = CursorLockMode.Confined;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0) {
			return;
		}
		
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");

		// Virtual Mouse
//		Vector3 deltaMouse = Input.mousePosition - lastCursor;
		Vector3 deltaMouse = new Vector3 (mouseX * mouseSpeed, mouseY * mouseSpeed, 0.0f);
		Vector3 newVirtualMousePosition = virtualCursor + deltaMouse;
//		lastCursor = Input.mousePosition;
		//


//		Vector3 targetVector = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
		Vector3 targetVector = newVirtualMousePosition;

		Vector2 center = new Vector3 (Screen.width / 2.0f, Screen.height / 2.0f, 0);

		float newX = Mathf.Clamp (targetVector.x, center.x - center.x * boundarySize, center.x + center.x * boundarySize);
		float newY = Mathf.Clamp (targetVector.y, center.y - center.y * boundarySize, center.y + center.y * boundarySize);

		targetVector = new Vector3 (newX, newY, 0);
		virtualCursor = targetVector;
		virtualCursor = Vector3.Lerp (virtualCursor, center, 0.01f);

//		Debug.Log (targetVector);
		Ray ray = Camera.main.ScreenPointToRay(targetVector);
//		ray.origin = origin.transform.position;
		Debug.DrawRay (ray.origin, ray.direction * distance, Color.yellow);
		transform.position = ray.origin + ray.direction * distance;

		if (mouseMovesShip) {

//			Debug.Log(virtualCursor);s

			float logX = targetVector.x - center.x;
			float logY = targetVector.y - center.y;

			logX = logX / (center.x * boundarySize);
			logY = -logY / (center.y * boundarySize);

			origin.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.up * logX * 20);
			origin.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.right * logY * 20);
//			transform.parent.RotateAround(transform.parent.position, transform.parent.up, 20 * Time.deltaTime * logX);
//			transform.parent.RotateAround(transform.parent.position, transform.parent.right, 20 * Time.deltaTime * logY);
		}
	}


}
