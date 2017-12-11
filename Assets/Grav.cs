using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grav : MonoBehaviour {

	public float grav;

	void Start(){

		Rigidbody rb = GetComponent<Rigidbody>();
		rb.velocity = transform.up * -grav;


	}	
}
