using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AcceptedJobs_Details : MonoBehaviour {

	public int IamNumber;

	public GameObject panel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click() {
		panel.SetActive(true);
		if (IamNumber == 1) {
			panel.GetComponent<AcceptedJobs_Details_Control>().Bring(GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted1, IamNumber);
		} else if (IamNumber == 2) {
			panel.GetComponent<AcceptedJobs_Details_Control>().Bring(GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted2, IamNumber);
		} else {
			panel.GetComponent<AcceptedJobs_Details_Control>().Bring(GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted3, IamNumber);
		}
 	}
}
