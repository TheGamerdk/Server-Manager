using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UI_Control : MonoBehaviour {

	public static UI_Control ui_control;
	public List<MonoBehaviour> CommandUpdateElements;
	public List<MonoBehaviour> ConstantUpdateElements;

	// Use this for initialization
	void Awake () {
		//Insure no multiple UI controllers are present
		if (ui_control == null) {
			ui_control = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
		//Clear Lists
		CommandUpdateElements.Clear();
		ConstantUpdateElements.Clear();
		//Update CommandElements
		OnCommandUpdate();
	}
	
	// Update is called once per frame
	void Update () {
		ConstantUpdate();
	}

	public void ConstantUpdate() {
		
	}

	public void OnCommandUpdate() {
		for(int i = 0; i < CommandUpdateElements.Count; i++) {
			CommandUpdateElements[i].GetComponent<Static_Text_Update_Command>().UpdateText();
		}
	}
}
