using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceMover : MonoBehaviour {

	public float speed;

	bool rightWallReached;
	bool leftWallReached;
	bool movingRight;
	bool movingLeft;

	void Start(){
		transform.Translate (Time.deltaTime * speed, 0, 0);
		leftWallReached = true;
		rightWallReached = false;
		movingRight = true;
		movingLeft = false;
	}


	void FixedUpdate(){
		if (movingRight) {

			if (transform.position.x >= 15.67f) {
				rightWallReached = true;
				leftWallReached = false;
				movingRight = false;
				movingLeft = true;
			}

			else if (!rightWallReached) {
				transform.Translate (Time.deltaTime * speed, 0, 0);
			}


		} else if (movingLeft)

			if (transform.position.x <= -15.67f) {
				rightWallReached = false;
				leftWallReached = true;
				movingRight = true;
				movingLeft = false;
			}
			else if (!leftWallReached) {
			transform.Translate (-Time.deltaTime * speed, 0, 0);
		}

			
		}

}
