using UnityEngine;
using System.Collections;

public class CPU_Close_Menu : MonoBehaviour {

	public GameObject panel;

	void Start () {
	
	}

	void Update () {
	
	}

	public void Click() {
		panel.SetActive(false);
	}
}
