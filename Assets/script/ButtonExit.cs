using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonExit : MonoBehaviour {

	public Button btn;
	void Start () {
		btn = gameObject.GetComponent<Button> ();
		btn.onClick.AddListener (Exit);
	}
	
	void Exit (){
		Application.Quit();
	}
}
