using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingContact : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Rigidbody rb = other.attachedRigidbody;
		rb.velocity = -transform.up;
	}

}
