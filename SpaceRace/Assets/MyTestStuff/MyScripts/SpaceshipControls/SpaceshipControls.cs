using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class SpaceshipControls : MonoBehaviour {
	
	public float verticalSpeed = 10f;
	public float maxVertSpeed = 100f;
	public float zRotationSpeed = 5f;
	public float maxZRotSpeed = 2f;
	public float Speed = 10f;
	public float maxSpeed = 100f;
	public float strafeSpeed = 10f;
	public float maxStafeSpeed = 20f;

	public float boostFactor = 1.5f;
	
	private Rigidbody rb;
	
	// Rotation Vars
	public float XSensitivity = 2f;
	public float YSensitivity = 2f;
	public bool clampVerticalRotation = true;
	public float MinimumX = -90F;
	public float MaximumX = 90F;
	public bool smooth;
	public float smoothTime = 5f;
	
	
	private Quaternion m_CharacterTargetRot;
	private Quaternion m_CameraTargetRot;

	//------


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		m_CharacterTargetRot = transform.localRotation;
//		m_CameraTargetRot = Camera.main.transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {

//		LookRotation (transform, Camera.main.transform);

		if (Input.GetKey (KeyCode.Space)) {
			rb.AddRelativeForce(new Vector3(0, 1, 0) * verticalSpeed);
		}
		
		if (Input.GetKey (KeyCode.LeftAlt)) {
			rb.AddRelativeForce(new Vector3(0, -1, 0) * verticalSpeed);
		}

		if (Input.GetKey (KeyCode.Q)) {
//			transform.Rotate(new Vector3(0, 0, 1));
//			rb.AddRelativeTorque(new Vector3(0, 0, 1) * zRotationSpeed);
		}

		if (Input.GetKey (KeyCode.E)) {
//			rb.AddRelativeTorque(new Vector3(0, 0, -1) * zRotationSpeed);
		}
		
		if (Input.GetKey (KeyCode.W)) {
			float boost = Input.GetKey(KeyCode.LeftShift) ? boostFactor : 1f;
			rb.AddRelativeForce(new Vector3(0, 0, 1) * Speed * boost);
		}

		if (Input.GetKey (KeyCode.S)) {
			rb.AddRelativeForce(new Vector3(0, 0, -1) * Speed);
		}

		if (Input.GetKey (KeyCode.Q)) {
			rb.AddRelativeForce(new Vector3(-1, 0, 0) * strafeSpeed);
		}
		
		if (Input.GetKey (KeyCode.E)) {
			rb.AddRelativeForce(new Vector3(1, 0, 0) * strafeSpeed);
		}

//		m_CharacterTargetRot = transform.localRotation;
//		m_CameraTargetRot = Camera.main.transform.localRotation;
	}
	
	void FixedUpdate()
	{
		if (rb.velocity.y > maxVertSpeed) {
			rb.velocity = new Vector3(rb.velocity.x, maxVertSpeed, rb.velocity.z);
		}

		if (rb.angularVelocity.z > maxZRotSpeed) {
			rb.angularVelocity = new Vector3(rb.angularVelocity.x, rb.angularVelocity.y, maxZRotSpeed);
		}

		if (rb.velocity.x > maxStafeSpeed) {
			rb.velocity = new Vector3(maxStafeSpeed, rb.velocity.y, rb.velocity.z);
		}

		if (rb.velocity.z > maxSpeed) {
			rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
		}
	}
		
	public void LookRotation(Transform character, Transform camera)
	{
		float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
		float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;

		float zRot = 0f;
		if (Input.GetKey (KeyCode.A)) {
			zRot += zRotationSpeed;
		}
		if (Input.GetKey (KeyCode.D)) {
			zRot -= zRotationSpeed;
		}

		m_CharacterTargetRot *= Quaternion.Euler (-xRot, yRot, zRot);
//		m_CameraTargetRot *= Quaternion.Euler (0f, 0f, 0f);
		
//		if(clampVerticalRotation)
//			m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);
		
		if(smooth)
		{
			character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot,
			                                            smoothTime * Time.deltaTime);
			camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot,
			                                         smoothTime * Time.deltaTime);
		}
		else
		{
			character.localRotation = m_CharacterTargetRot;
			camera.localRotation = m_CameraTargetRot;
		}
	}
}
