using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
	public int speed = 100;
	public float rotationSpeed = 0.1F;
	public float smoothTime = 0.3F;
	public int duckDist = 30;
	public int closeProxDist = 15;
	public int closeProxSpeed = 40;
	private Vector3 velocity = Vector3.zero;

	private Rigidbody rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject player = FindClosestPlayer();
		Quaternion playerDirection = Quaternion.LookRotation(player.transform.position-transform.position, player.transform.up);

		float relativeSpeed = speed;
		if((player.transform.position - transform.position).magnitude < closeProxDist){
			relativeSpeed = closeProxSpeed;
//			Debug.Log("Slow");
		} else {
//			Debug.Log("Fast");
		}

		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		if(Physics.Raycast(transform.position, fwd, out hit, duckDist)) {
			if(hit.collider.gameObject != player) {
				playerDirection = Quaternion.LookRotation(player.transform.up, player.transform.up);
//				print("Ausweichen");
			}
		}

		transform.rotation = Quaternion.Slerp(transform.rotation, playerDirection, rotationSpeed);
		//transform.LookAt(player.transform, Vector3.up);
		rb.velocity = Vector3.SmoothDamp(rb.velocity, transform.forward * relativeSpeed, ref velocity, smoothTime);
	}

	GameObject FindClosestPlayer() {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
