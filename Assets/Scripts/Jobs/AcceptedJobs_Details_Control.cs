using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AcceptedJobs_Details_Control : MonoBehaviour {

	public int current_number;
	public GameObject panel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Bring(string[] array, int number) {
		current_number = number;
		GameObject.Find("Slot_Number_Text").GetComponent<Text>().text = "Currently accepted job from " + array[1];
		GameObject.Find("Slot_Job").GetComponent<Text>().text = "Their job is " + array[2];
		GameObject.Find("Slot_CPU_Usage").GetComponent<Text>().text = "They are using " + array[3] + "Ghz of CPU power";
		GameObject.Find("Slot_Storage_Usage").GetComponent<Text>().text = "They are using " + array[4] + "GB of storage";
		GameObject.Find("Slot_Pay").GetComponent<Text>().text = "They pay " + array[5] + "$ per week";
	}

	public void CancelCurrentJob() {
		if (current_number == 1) {
			for (int i = 0; i < GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted1.Length; i++) {
				GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted1[i] = null;
			}
			GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted1[0] = "0";
		} else if (current_number == 2) {
			for (int i = 0; i < GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted2.Length; i++) {
				GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted2[i] = null;
			}
			GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted2[0] = "0";
		} else if (current_number == 3) {
			for (int i = 0; i < GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted3.Length; i++) {
				GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted3[i] = null;
			}
			GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted3[0] = "0";
		} /*else if (current_number == 4) {
			for (int i = 0; i < GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted4.Length; i++) {
				GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted4[i] = null;
			}
			GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted4[0] = "0";
		} else if (current_number == 5) {
			for (int i = 0; i < GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted5.Length; i++) {
				GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted5[i] = null;
			}
			GameObject.Find("GameControl").GetComponent<Job_Central>().Accepted5[0] = "0";
		} */
		gameObject.SetActive(false);
		panel.SetActive(false);
	}
}
