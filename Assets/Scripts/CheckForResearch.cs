using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckForResearch : MonoBehaviour {

	public string required_research;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text>().text = "Requires " + required_research;
		if (Research_Central.research.CheckResearch(required_research) == true) {
			transform.parent.GetComponent<Button>().enabled = true;
			gameObject.SetActive(false);
		}
	}
}
