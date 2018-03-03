using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class BallControlllvl3 : MonoBehaviour {
	private int speed =600; 
	private Rigidbody rb;
	private int point;
	private bool gameOver;
	Text score;
	Text time;
	float second;
	private Text ending;
	int numberOfTarget;
	private Text lvl3;
	void Start () {
		gameOver = false;
		numberOfTarget = GameObject.FindGameObjectsWithTag ("Target").Length;
		rb=GetComponent<Rigidbody>();
		time = GameObject.Find ("/Canvas/Time").GetComponent<Text> ();
		score =GameObject.Find("/Canvas/Score"). GetComponent<Text>();
		ending = GameObject.Find ("Canvas/GameOver").GetComponent<Text>();

		lvl3 = GameObject.Find ("/Canvas/Lvl3").GetComponent<Text>();
		point = 0 ;
		SetScore ();
		second = 0.0f;
		SetTime ();

	}

	void Update () {

		if ((point < numberOfTarget) &&   gameOver == false) {
			second += Time.deltaTime;
			SetTime ();
		} 
		else {
			//rb.isKinematic = true;
		if (gameOver == true) {
				SetEndingText ("Game Over ");
				StartCoroutine (Back ());
			}
			else {
				SetEndingText (" Well Done ! ");
				lvl3.text = "Level 3 : " + second.ToString ();
				StartCoroutine (Back ());
			}



		}
	}
	void FixedUpdate () {

		float vertical = Input.GetAxis ("Vertical") * speed * Time.deltaTime ;
		float horizontal = Input.GetAxis ("Horizontal") * speed * Time.deltaTime ;
		Vector3 move = new Vector3 (horizontal, 0.0f, vertical);
		rb.AddForce(move);
	}
	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag ("Target")) {
			other.gameObject.SetActive (false);
			point++;
			SetScore ();

		}
		else if (other.gameObject.CompareTag ("Danger")) {
			gameOver = true;
			//rb.isKinematic = true;
			//SetEndingText ("Game Over ");
		}

	}
	void SetScore(){
		score.text = "Score: " + point.ToString ();
	}
	void SetTime(){
		
		time.text = "Time : " + second.ToString ();
	}
	void SetEndingText(string s){
		ending.text = s;

	}
	IEnumerator Back (){

		yield return new WaitForSeconds (5);
		SceneManager.LoadScene ("Main");
	}

}
