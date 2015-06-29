using UnityEngine;
using System.Collections;

public class RocketMover : MonoBehaviour { 

	public GameObject target;
	public float speed;
	public float angularSpeed;

//	private Rigidbody rb;

	//0 = kein Ziel, 1 = Düsen an, 2 = Flug zum Ziel, 3 = Flug + Collider
	int LaunchState = 0;
	float launchTime;

	private float colliderDelay = 0.5f;
	private float timeToStart = 2;

	// Use this for initialization
	void Start () {
//		rb = GetComponent<Rigidbody> ();
		transform.GetChild (1).gameObject.SetActive(false);
	}

	public void launch(){
		LaunchState = 1;
		transform.GetChild (1).gameObject.SetActive(true);
		launchTime = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {

		if (LaunchState == 0) {
			return;
		}

		if (LaunchState == 1) {
			if(launchTime + timeToStart <= Time.fixedTime){
				LaunchState = 2;
			}
			else
				return;
		}

		if (LaunchState == 2) {
			if(launchTime + timeToStart + colliderDelay <= Time.fixedTime){
				transform.GetChild(0).gameObject.GetComponent<CapsuleCollider>().enabled = true;
				LaunchState = 3;
			}
		}


		if (target == null) {
			transform.GetChild(1).GetComponent<ParticleSystem>().Stop();
			transform.GetChild(1).parent = null;
			Destroy(gameObject);
			return;
		}

		Vector3 direction = target.transform.position - transform.position;


		float step = angularSpeed * Time.deltaTime;

		Vector3 newDir = Vector3.RotateTowards(transform.forward, direction, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);


		transform.position += transform.forward * speed;


	}
}
