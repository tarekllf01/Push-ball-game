using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelOneHolder : MonoBehaviour {
	
	public Text t;
	public static string lvl;
	// Use this for initialization
	void Start () {
		t = gameObject.GetComponent<Text>();
		t.text = lvl;
	}

	
	// Update is called once per frame
	void Update () {
		lvl = t.text;
	}


}
