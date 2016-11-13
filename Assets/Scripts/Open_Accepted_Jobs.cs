using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Open_Accepted_Jobs : MonoBehaviour {

	public GameObject panel;
	public GameObject container1;
	public GameObject container2;
	public GameObject container3;
	public GameObject container4;
	public GameObject container5;
	public GameObject test;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click() {
		panel.SetActive(true);

		if (Job_Central.job_centrals.Accepted1[0] != "0") {
			container1.GetComponent<Text>().text = "Job From " + Job_Central.job_centrals.Accepted1[1] + "\n" + "Job Type: " + 
			Job_Central.job_centrals.Accepted1[2] + "\n" + "They are using " + Job_Central.job_centrals.Accepted1[3] + "Ghz of CPU" + "\n" + "They are using " + Job_Central.job_centrals.Accepted1[4] + "GB of storage" + "\n" + "They pay " + Job_Central.job_centrals.Accepted1[5] + "$ per week";
		} else {
			container1.GetComponent<Text>().text = "No Job in this slot";
		}

		if (Job_Central.job_centrals.Accepted2[0] != "0") {
			container2.GetComponent<Text>().text = "Job From " + Job_Central.job_centrals.Accepted2[1] + "\n" + "Job Type: " + 
			Job_Central.job_centrals.Accepted2[2] + "\n" + "They are using " + Job_Central.job_centrals.Accepted2[3] + "Ghz of CPU" + "\n" + "They are using " + Job_Central.job_centrals.Accepted2[4] + "GB of storage" + "\n" + "They pay " + Job_Central.job_centrals.Accepted2[5] + "$ per week";
		} else {
			container2.GetComponent<Text>().text = "No Job in this slot";
		}

		if (Job_Central.job_centrals.Accepted3[0] != "0") {
			container3.GetComponent<Text>().text = "Job From " + Job_Central.job_centrals.Accepted3[1] + "\n" + "Job Type: " + 
				Job_Central.job_centrals.Accepted3[2] + "\n" + "They are using " + Job_Central.job_centrals.Accepted3[3] + "Ghz of CPU" + "\n" + "They are using " + Job_Central.job_centrals.Accepted3[4] + "GB of storage" + "\n" + "They pay " + Job_Central.job_centrals.Accepted3[5] + "$ per week";
		} else {
			container3.GetComponent<Text>().text = "No Job in this slot";
		}
	}
}
