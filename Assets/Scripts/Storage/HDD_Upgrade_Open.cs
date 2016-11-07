using UnityEngine;
using System.Collections;

public class HDD_Upgrade_Open : MonoBehaviour {

	public GameObject IAm;
	public GameObject panel;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		IAm = gameObject;
	}

	public void Click() {
		panel.SetActive(true);
		panel.GetComponent<HDD_Upgrade_Manager>().serving = IAm;
	}
}
