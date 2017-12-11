using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject block;
	public GameObject cola;
	public Vector3 spawnValues;
	public int blockCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public float colaStartWait;
	public float colaSpawnWait;
	public int colaCount;

	public GUIText timeText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText playerTime;
	public GUIText introText;
	public GUIText instructions;
	public GUIText noGravityText;

	private bool gameOver;
	private bool restart;
	private string niceTime;
	private string countDown;
	public Time time;

	public static float timer = 0.0f;
	public static bool timeStarted = false;

	public bool noGravity;
	public GameObject player;

	void Start(){

		gameOver = false;
		restart = false;

		introText.text = "Don't Fall!";
		instructions.text ="Press <space> to jump \n"
			+ "<left> & <right> arrow keys to move";
		restartText.text = "";
		gameOverText.text = "";
		playerTime.text = "";
		noGravityText.text = "";

		UpdateTime ();
		StartCoroutine(SpawnBlocks ());
		StartCoroutine (SpawnCola ());

		timeStarted = true;



	}

	void Update(){
		if (!gameOver) {
			UpdateTime ();
		}

		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}

		if (timeStarted) {
			timer += Time.deltaTime;

			if (timer >= 4f) {
				introText.text = "";
				instructions.text = "";
			}
		}

		if (noGravity) {
			Rigidbody rb = player.GetComponent<Rigidbody> ();
			StartCoroutine (ballFloat (rb));
		}
	}

	IEnumerator SpawnBlocks(){

		yield return new WaitForSeconds(startWait);

		while (!gameOver) {

			for (int i = 0; i < blockCount; i++) {

				if (gameOver)
					break;
				Vector3 spawnPosition = new Vector3 (18f,Random.Range (-4.6f, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (block, spawnPosition, spawnRotation);		
				yield return new WaitForSeconds (Random.Range (1f, spawnWait));
			}

			//yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				timer = 0.0f;
				timeStarted = false;
				break;
			}
		}

	}

	IEnumerator SpawnCola(){

		yield return new WaitForSeconds(colaSpawnWait);

		while (!gameOver) {

			for (int i = 0; i < colaCount; i++) {
				Vector3 spawnColaPosition = new Vector3 (Random.Range (-17f, 17f), Random.Range (-2f, 9f), 0.0f);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (cola, spawnColaPosition, spawnRotation);
				yield return new WaitForSeconds (Random.Range (5f, colaSpawnWait));
			}
		}

	}

	void UpdateTime()
	{
		int minutes = Mathf.FloorToInt(timer / 60F);
		int seconds = Mathf.FloorToInt(timer - minutes * 60);
		niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

		timeText.text = "Time: " + niceTime;
	}

	public void GameOver()
	{
		gameOver = true;
		gameOverText.text = "Game Over";
		playerTime.text = "Your time was: " + niceTime;

	}

	IEnumerator ballFloat(Rigidbody rb){

		bool grav = true;
		rb.useGravity = false;

		float noGravTime = 3f;
	

		while (noGravTime >= 0) {
			noGravTime -= Time.deltaTime;
			rb.velocity = transform.up * 3f;
			Vector3 movement = new Vector3 (Input.GetAxis("Horizontal"), 0.0f, 0.0f);
			rb.AddForce (movement * 3f);

			noGravityText.text = "No Gravity";

			yield return null;
		}

		rb.useGravity = grav;
		noGravity = false;
		noGravityText.text = "";

	}
		

}
