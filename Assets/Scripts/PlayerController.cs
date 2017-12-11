using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

	public Boundary boundary;
	private float jumpForce;
	public float speed = 7;
	public SphereCollider sc;
	public LayerMask groundLayer;

	public bool noGravity;
	private float noGravityTimer;

	void Start () {
		sc = GetComponent<SphereCollider>();
	}
	

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.AddForce (movement * speed);


		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax),
			0.0f
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * 5.7f);

	}

	void Update(){

		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.drag = 0;

		if (rb.position.y >= 4.5f) {
			jumpForce = 9f;
		} else {
			jumpForce = 12f;
		}
			
		if (IsGrounded() && Input.GetKey ("space")) {	
			rb.AddForce (Vector3.up * jumpForce,  ForceMode.Impulse);

		}

	


	}

	private bool IsGrounded()
	{
		return Physics.CheckCapsule (sc.bounds.center, new Vector3 (sc.bounds.center.x, sc.bounds.min.y, sc.bounds.center.z), 
			sc.radius * .9f, groundLayer);
	}


		
}
