using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Server_Data : MonoBehaviour {

	public static Server_Data server_dat;
	public float needed;
	public float used;
	public bool filled;
	public float combined_speed; 

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
	}
	
	// Only call this if REALLY needed!
	void ClearAllValues() {
		combined_speed = 0;
	}
	//Updates server stats
	void Update () {
		GameObject.Find("Speed_Text").GetComponent<Text>().text = "Total Speed/Capacity: " + combined_speed + "Ghz";
	}

	//Assign capacity
	public void AssignCapacity() {
		float temp = 0;
		float temp2 = 0;
		float temp3 = 0;
		if (Job_Central.job_centrals.Accepted1[3] != null) {
			float.TryParse(Job_Central.job_centrals.Accepted1[3], out temp);
		}
		if (Job_Central.job_centrals.Accepted2[3] != null) {
			float.TryParse(Job_Central.job_centrals.Accepted2[3], out temp2);
		}
		if (Job_Central.job_centrals.Accepted2[3] != null) {
			float.TryParse(Job_Central.job_centrals.Accepted3[3], out temp3);
		}
		needed = temp + temp2 + temp3;
		used = needed;
		GameObject.Find("Speed_Text_Usage").GetComponent<Text>().text = "Used Capacity: " + used + "/" + combined_speed + "Ghz";
		if (needed > combined_speed) {
			float local_needed = needed;
			used = 0;
			used = combined_speed;
			local_needed = needed - combined_speed;
			GameObject.Find("Speed_Text_Usage").GetComponent<Text>().text = "Used Capacity: " + used + "/" + combined_speed + "Ghz" + "\n" + "<color=red>WARNING! Capacity Filled!</color>" + "\n" + "Need " + local_needed + " more Ghz of Capacity";
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
	}
}
