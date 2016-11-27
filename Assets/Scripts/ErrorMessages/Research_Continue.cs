using UnityEngine;
using System.Collections;

public class Research_Continue : MonoBehaviour {

	public GameObject caller;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click() {
		caller.GetComponent<Research_Element>().Continue();
	}
}
