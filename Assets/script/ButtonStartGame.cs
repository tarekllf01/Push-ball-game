using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonStartGame : MonoBehaviour {
	public Button btn;

	void Start(){
		btn = gameObject.GetComponent<Button> ();

		btn.onClick.AddListener (GoTo);

	}
	void GoTo () {
		SceneManager.LoadScene ("Main");
	}
}
