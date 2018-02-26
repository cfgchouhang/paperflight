using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour {
	private Vector3 mouseDownPosition, velocity;
	public float initVelocity;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 (initVelocity, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if (Input.GetMouseButtonDown (0)) {
			mouseDownPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y);
		} else if (Input.GetMouseButtonUp (0)) {
			velocity = new Vector3 (Input.mousePosition.x - mouseDownPosition.x, Input.mousePosition.y - mouseDownPosition.y);
		}
		rb.velocity += velocity * Time.deltaTime;
	}
}
