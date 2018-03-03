using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (1.0f, 1.0f, 1.0f);
		//check transform.Translate(1.0f, 0.0f, 0.0f);
	
	}
}
