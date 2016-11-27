using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Research_Element : MonoBehaviour {

	public string research_name;
	public int cost;
	public int weeks;
	public string research_required;

	// Use this for initialization
	void Start () {
		Research_Central.research.research_elements.Add(research_name, false);
	}
	
	// Update is called once per frame
	void Update () {
		Color grey = new Color(0.75f, 0.75f, 0.75f);
		Color normal = new Color(255f,255f,255f);
		gameObject.GetComponentInChildren<Text>().text = research_name + "\n\n" + cost + "$" + "\n" + weeks + " weeks";
		foreach(KeyValuePair<string, bool> keyvalues in Research_Central.research.research_elements) {
			if (keyvalues.Key == research_name) {
				if (keyvalues.Value == true) {
					gameObject.GetComponentInChildren<Text>().text = research_name + "\n\n" + "Already Researched";
					gameObject.GetComponent<Button>().interactable = false;
				}
			}
		}
		if (research_required != "None") {
			foreach(KeyValuePair<string, bool> value in Research_Central.research.research_elements) {
				if (value.Key == research_required) {
					if (value.Value == true) {
						gameObject.GetComponent<Image>().color = normal;
					} else {
						gameObject.GetComponent<Image>().color = grey;
					}
				}
			}
		}
	}

	public void Click() {
		if (research_required != "None") {
			foreach(KeyValuePair<string, bool> value in Research_Central.research.research_elements) {
				if (value.Key == research_required) {
					if (value.Value == false) {
						return;
					} 
				}
			}
		}
		if (Research_Central.research.has_research == false) {
			Research_Central.research.StartResearch(weeks, cost, research_name);
			GameObject.Find("Upgrades").SetActive(false);
		} else {
			ErrorResearchRunning();
		}
	}

	public void ErrorResearchRunning() {
		GameObject error = Server_Data.server_dat.error_panel;
		error.SetActive(true);
		error.GetComponentInChildren<Text>().text = "You already have a research running!" + "\n" + "You will not be refunded if you press the continue button!";
		GameObject.Find("Error1_Research").GetComponentInChildren<Text>().text = "Continue";
		GameObject.Find("Error2_Research").GetComponentInChildren<Text>().text = "Cancel";
		GameObject.Find("Error1_Research").GetComponent<Research_Continue>().caller = gameObject;
		GameObject.Find("Error2_Research").GetComponent<Research_Cancel>().caller = gameObject;

	}

	public void Continue() {
		Research_Central.research.StartResearch(weeks, cost, research_name);
		Server_Data.server_dat.error_panel.SetActive(false);
	}

	public void Close() {
		Server_Data.server_dat.error_panel.SetActive(false);
	}
}
