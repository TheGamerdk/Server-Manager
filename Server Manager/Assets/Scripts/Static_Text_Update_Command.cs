using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Static_Text_Update_Command : MonoBehaviour {

	public string Textname;

	// Use this for initialization
	void Awake() {
		UI_Control.ui_control.CommandUpdateElements.Add(this);
	}
	
	// Update is called once per frame
	public void UpdateText () {
		GetComponent<Text>().text = Textname;
	}
}
