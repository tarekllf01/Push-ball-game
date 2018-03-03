using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class BallControlllvl2 : MonoBehaviour {
	private int speed =300; 
	private Rigidbody rb;
	private int point;
	private bool gameOver;
	Text score;
	Text time;
	float second;
	private Text ending;
	int numberOfTarget;
	private Text lvl2,lvl1;
	void Start () {
		gameOver = false;
		numberOfTarget = GameObject.FindGameObjectsWithTag ("Target").Length;
		rb=GetComponent<Rigidbody>();
		time = GameObject.Find ("/Canvas/Time").GetComponent<Text> ();
		score =GameObject.Find("/Canvas/Score"). GetComponent<Text>();
		ending = GameObject.Find ("Canvas/GameOver").GetComponent<Text>();
		lvl2 = GameObject.Find ("/Canvas/Lvl2").GetComponent<Text>();
		//lvl1 = GameObject.Find ("/Canvas/Lvl1").GetComponent<Text> ();
	
		// lvl1.text = "Level1: ";
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
			rb.isKinematic = true;
		if (gameOver == true) {
				SetEndingText ("Game Over ");
				StartCoroutine (Back());

			}
			else {
				lvl2.text = "Level2 : " + second.ToString ();
				SceneManager.LoadScene ("Level3");
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
