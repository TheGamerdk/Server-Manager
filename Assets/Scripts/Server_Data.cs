using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Server_Data : MonoBehaviour {

	public GameObject[] servers;
	public static Server_Data server_dat;
	public float needed_speed;
	public float used_speed;
	public float needed_space;
	public float used_space;
	public bool filled;
	public float combined_speed; 
	public float combined_storage;
	public GameObject error_panel;

	// Use this for initialization
	void Awake () {
		//Insure no multiple Server Databases are present
		filled = false;
		if (server_dat == null) {
			server_dat = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
		AssignCapacity();
	}
	
	// Only call this if REALLY needed!
	void ClearAllValues() {
		combined_speed = 0;
	}
	//Updates server stats
	void Update () {
		GameObject.Find("Speed_Text").GetComponent<Text>().text = "Total Speed/Capacity: " + combined_speed + "Ghz";
		GameObject.Find("Space_Text").GetComponent<Text>().text = "Total Space/Capacity: " + combined_storage + "GB";
		AssignCapacity();
		Color grey = new Color(0.75f, 0.75f, 0.75f);
		Color normal = new Color(0.4f, 0.4f, 0.4f);
		if (servers[0].activeSelf == true) {
			GameObject.Find("Server1").GetComponent<Image>().color = grey;
			GameObject.Find("Server2").GetComponent<Image>().color = normal;
		} else if (servers[1].activeSelf == true) {
			GameObject.Find("Server2").GetComponent<Image>().color = grey;
			GameObject.Find("Server1").GetComponent<Image>().color = normal;
		} 
	}



	//Assign capacity
	public void AssignCapacity() {
		used_speed = needed_speed;
		used_space = needed_space;
		GameObject.Find("Speed_Text_Usage").GetComponent<Text>().text = "Used Capacity: " + used_speed + "/" + combined_speed + "Ghz";
		GameObject.Find("Space_Text_Usage").GetComponent<Text>().text = "Used Capacity: " + used_space + "/" + combined_storage + "GB";
		if (needed_speed > combined_speed) {
			float local_needed = needed_speed;
			used_speed = 0;
			used_speed = combined_speed;
			local_needed = needed_speed - combined_speed;
			GameObject.Find("Speed_Text_Usage").GetComponent<Text>().text = "Used Capacity: " + used_speed + "/" + combined_speed + "Ghz" + "\n" + "<color=red>WARNING! Capacity Filled!</color>" + "\n" + "Need " + local_needed + " more Ghz of Capacity";
		}
		if (needed_space > combined_storage) {
			float local_needed = needed_space;
			used_space = 0;
			used_space = combined_storage;
			local_needed = needed_space - combined_storage;
			GameObject.Find("Space_Text_Usage").GetComponent<Text>().text = "Used Capacity: " + used_space + "/" + combined_storage + "GB" + "\n" + "<color=red>WARNING! Capacity Filled!</color>" + "\n" + "Need " + local_needed + " more GB of Space";
		}
	}
		
	public void CalculateWeek() {
			int temp;
			int.TryParse(Job_Central.job_centrals.Accepted1[5], out temp);
			Company_Data.company_dat.money += temp;
			int.TryParse(Job_Central.job_centrals.Accepted2[5], out temp);
			Company_Data.company_dat.money += temp;
			int.TryParse(Job_Central.job_centrals.Accepted3[5], out temp);
			Company_Data.company_dat.money += temp;
		for (int i = 0; i < Job_Central.job_centrals.JobOffer1.Length; i++) {
			Job_Central.job_centrals.JobOffer1[i] = null;
		}
		for (int i = 0; i < Job_Central.job_centrals.JobOffer2.Length; i++) {
			Job_Central.job_centrals.JobOffer2[i] = null;
		}
		for (int i = 0; i < Job_Central.job_centrals.JobOffer3.Length; i++) {
			Job_Central.job_centrals.JobOffer3[i] = null;
		}
		for (int i = 0; i < Job_Central.job_centrals.filled_spaces.Length; i++) {
			Job_Central.job_centrals.filled_spaces[i] = false;
		}
		Job_Central.job_centrals.RandomiseJob(Job_Central.job_centrals.JobOffer1);
		Job_Central.job_centrals.RandomiseJob(Job_Central.job_centrals.JobOffer2);
		Job_Central.job_centrals.RandomiseJob(Job_Central.job_centrals.JobOffer3);
		Research_Central.research.Process();
		Company_Data.company_dat.weeknum++;
	}
}
