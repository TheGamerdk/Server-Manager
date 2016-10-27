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
		used = needed;
		GameObject.Find("Speed_Text_Usage").GetComponent<Text>().text = "Used Capacity: " + used + "/" + combined_speed + "Ghz";
		if (needed > combined_speed) {
			used = 0;
			used = combined_speed;
			needed = needed - combined_speed;
			GameObject.Find("Speed_Text_Usage").GetComponent<Text>().text = "Used Capacity: " + used + "/" + combined_speed + "Ghz" + "\n" + "<color=red>WARNING! Capacity Filled!</color>" + "\n" + "Need " + needed + " more Ghz of Capacity";
		}
	}
		

}
