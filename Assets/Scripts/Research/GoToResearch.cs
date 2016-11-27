using UnityEngine;
using System.Collections;

public class GoToResearch : MonoBehaviour {

	public GameObject panel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click() {
		panel.SetActive(true);
	}
}
