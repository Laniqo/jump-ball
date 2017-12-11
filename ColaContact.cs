using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaContact : MonoBehaviour {

	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	void OnTriggerEnter( Collider other){
		float timer = 6f;
		if (other.tag == "Player") {
			Destroy (gameObject);
			//other.attachedRigidbody.useGravity = false;


			gameController.noGravity = true;

		}
	}
}
