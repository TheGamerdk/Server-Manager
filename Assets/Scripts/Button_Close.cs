using UnityEngine;
using System.Collections;

public class Button_Close : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click() {
		target.SetActive(!target.activeSelf);
	}
}
