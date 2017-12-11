using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	public float speed;
	void Update() {
		transform.Translate( -Time.deltaTime * Random.Range (1, speed), 0, 0);

	}

}