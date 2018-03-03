using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallControll : MonoBehaviour {
	private int speed =300;
	private Rigidbody rb;
	private int point;
	Text score,lvl1;
	Text time;
	int numberOfTarget;
	public  float second;

	void Start () {
		numberOfTarget = GameObject.FindGameObjectsWithTag ("Target").Length;
		rb=GetComponent<Rigidbody>();
		time = GameObject.Find ("/Canvas/Time").GetComponent<Text> ();
		point = 0 ;
		score =GameObject.Find("/Canvas/Score"). GetComponent<Text>();
		lvl1 =GameObject.Find("/Canvas/Lvl1"). GetComponent<Text>();
		SetScore ();
		second = 0.0f;
		SetTime ();

	}


	void Update () {

		if (point < numberOfTarget) {
			second += Time.deltaTime;
			SetTime ();
		} else {
			rb.isKinematic = true;
			lvl1.text = "Level 1: " + second.ToString();
			SceneManager.LoadScene ("Level2");

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

	}
	void SetScore(){
		score.text = "Score: " + point.ToString ();
	}
	void SetTime(){
		
		time.text = "Time : " + second.ToString ();


	}

}
