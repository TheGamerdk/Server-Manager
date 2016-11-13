using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Version_Control : MonoBehaviour {

	public string local_version;
	public string global_version;
	private Text version_text;


	// Use this for initialization
	void Start () {
		version_text = GameObject.Find("GameVersion_Text").GetComponent<Text>();
		version_text.text = local_version;
		StartCoroutine(CheckVersion());

	}

	IEnumerator CheckVersion() {
		WWW net = new WWW("https://raw.githubusercontent.com/TheGamerdk/Server-Manager/dev/version.txt");
		yield return net;
		if (net.error != null) {
			Debug.LogWarning("Error on version control: " + net.error);
		} 

		global_version = net.text;
		global_version = global_version.Trim();
		if (local_version != global_version) {
			version_text.text = version_text.text + "\n" + "<color=red>Running outdated version!" + "\n" + "Latest version is " + global_version + "</color>";
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
