using UnityEngine;
using System.Collections;

public class GoToDetailsListener : MonoBehaviour {

	public int IamNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click() {
		if (IamNumber == 1) {
			GameObject.Find("GameControl").GetComponent<Job_Central>().GoToDetails(GameObject.Find("GameControl").GetComponent<Job_Central>().JobOffer1, 1);
		} else if (IamNumber == 2) {
			GameObject.Find("GameControl").GetComponent<Job_Central>().GoToDetails(GameObject.Find("GameControl").GetComponent<Job_Central>().JobOffer2, 2);
		} else {
			GameObject.Find("GameControl").GetComponent<Job_Central>().GoToDetails(GameObject.Find("GameControl").GetComponent<Job_Central>().JobOffer3, 3);
		}
	}
}
