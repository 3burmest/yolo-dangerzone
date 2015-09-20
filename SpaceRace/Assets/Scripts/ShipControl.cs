using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour {
	public int speed = 100;
	public int rotationSpeed = 10;
	Rigidbody rb;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;

	void Awake() {
		Object.DontDestroyOnLoad(gameObject);
		if (FindObjectsOfType(GetType()).Length > 1) {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddRelativeTorque(-Vector3.forward * Input.GetAxis("Horizontal") * rotationSpeed);
		rb.AddRelativeTorque(-Vector3.left * Input.GetAxis("Vertical") * rotationSpeed);
		rb.AddRelativeTorque(-Vector3.up * Input.GetAxis("LeftRight") * rotationSpeed);

		
		//rb.velocity += (transform.forward * speed);
		rb.velocity = Vector3.SmoothDamp(rb.velocity, transform.forward * speed, ref velocity, smoothTime);
	}

	void OnLevelWasLoaded(int level) {
		Debug.Log(level);
		if (level == 2) {
			transform.position = new Vector3(0,0,0);
			try {
				transform.LookAt(GameObject.FindWithTag("BattleCruiser").transform);
				} catch (System.Exception e) {
					Debug.LogException(e);
				}
		} else if (level == 1) {
			transform.position = new Vector3(7000.0f,12.7f,0.0f);
			transform.rotation = Quaternion.Euler(0, 0, 0);
			try {
				transform.LookAt(GameObject.FindWithTag("Checkpoint").transform);
			} catch (System.Exception e) {
					Debug.Log(e);
			}
		}
	}
}
