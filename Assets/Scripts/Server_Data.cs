using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Server_Data : MonoBehaviour {

	public static Server_Data server_dat;
	public float needed_speed;
	public float used_speed;
	public float needed_space;
	public float used_space;
	public bool filled;
	public float combined_speed; 
	public float combined_storage;

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
	}



	//Assign capacity
	public void AssignCapacity() {
		used_speed = needed_speed;
		used_space = needed_space;
		GameObject.Find("Speed_Text_Usage").GetComponent<Text>().text = "Used Capacity: " + used_speed + "/" + combined_speed + "Ghz";
		GameObject.Find("Space_Text_Usage").GetComponent<Text>().text = "Used Capacity: " + used_speed + "/" + combined_speed + "GB";
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
	}
}
