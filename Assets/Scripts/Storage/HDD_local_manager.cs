using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HDD_local_manager : MonoBehaviour {

	public bool HasHDD;

	public float amount;

	public Sprite HDD;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (HasHDD == true) {
			gameObject.GetComponent<Image>().sprite = HDD;
			gameObject.GetComponentInChildren<Text>().text = amount + "GB";

		}
	}

	public void PushToCentral() {
		Server_Data.server_dat.combined_storage += amount;
		Server_Data.server_dat.AssignCapacity();
	}

	public void EmptyOwnCapacity() {
		Server_Data.server_dat.combined_storage -= amount;
	}
}
