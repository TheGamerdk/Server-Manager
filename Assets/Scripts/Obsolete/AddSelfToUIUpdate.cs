// DO NOT USE!
// Use the respective Static_Text_Update(_command or _constant) for things with only text changing (no variables)
// 

/*

using UnityEngine;
using System.Collections;

public class AddSelfToUIUpdate : MonoBehaviour {

	public bool constant;
	public bool command;

	// ALWAYS ASSIGN TO TEXT ELEMENT OR STUFF BREAKS!
	void Start () {
		if (constant == true) {
			UI_Control.ui_control.ConstantUpdateElements.Add(gameObject);
		} else if (command == true) {
			UI_Control.ui_control.CommandUpdateElements.Add(gameObject);
		} else {
			Debug.LogWarning("No command assigned to: " + gameObject);
		}
	}
}
*/