using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject ball;

	private Vector3 difference;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindGameObjectWithTag("Ball");
		difference = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		transform.position = ball.transform.position + difference;
	}
}
