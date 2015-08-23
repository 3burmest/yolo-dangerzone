using UnityEngine;
using System.Collections;

public class RocketMover2 : MonoBehaviour {

	public GameObject target;

	private Rigidbody myTarget;

	public GameObject front, back;

	public float speed;
	public float angularSpeed;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		myTarget = target.GetComponent<Rigidbody> ();
	}


	void Update()
	{

	}
	
    void FixedUpdate () 
	{

	}
}
