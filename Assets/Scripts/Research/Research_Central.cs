using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Research_Central : MonoBehaviour {

	//The finest scientists in the world!
	public static Research_Central research;

	public bool has_research;
	public string research_name;
	public Dictionary<string, bool> research_elements;
	public int weeks_to_go;

	// Use this for initialization
	void Start () {
		research_elements = new Dictionary<string, bool>();
		//No duplicate Research_Centrals
		if (research == null) {
			research = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (has_research == true) {
			GameObject.Find("Research_Name").GetComponentInChildren<Text>().text = "Currently researching: " + research_name;
			GameObject.Find("Research_Time").GetComponentInChildren<Text>().text = "Weeks remaining: " + weeks_to_go;
		} else {
			GameObject.Find("Research_Name").GetComponentInChildren<Text>().text = "";
			GameObject.Find("Research_Time").GetComponentInChildren<Text>().text = "";
		}
	}

	public void StartResearch(int weeks, int cost, string name) {
		has_research = true;
		weeks_to_go = weeks;
		Company_Data.company_dat.money -= cost;
		research_name = name;
	}

	public void Process() {
		if (has_research == true) {
			if (weeks_to_go == 1) {
				has_research = false;
				research_elements.Remove(research_name);
				research_elements.Add(research_name, true);
				weeks_to_go = 0;
			} else {
				weeks_to_go--;
			}
		}
	}

	//Returns whether research with specified name is researched or not, always return false if research element is not found
	public bool CheckResearch(string name) {
		
		bool temp;
		if (research_elements.TryGetValue(name, out temp)) {
			return temp;
		} else {
			return false;
		}
	}

}
