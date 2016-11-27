using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoToServer1 : MonoBehaviour {

	public GameObject[] objects;
	public GameObject[] enable_objects;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void Click() {
		for(int i = 0; i < objects.Length; i++) {
			objects[i].SetActive(false);
		}
		for(int i = 0; i < enable_objects.Length; i++) {
			enable_objects[i].SetActive(true);
		}

	}
}
