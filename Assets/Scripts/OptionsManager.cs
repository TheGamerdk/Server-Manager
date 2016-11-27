using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

	public string html_color;
	//public GameObject camera_object;
	public static OptionsManager options;

	// Use this for initialization
	void Start () {
		if (options == null) {
			options = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().buildIndex == 0) {
			html_color = GameObject.Find("BGColor").GetComponent<InputField>().text;
		} else {
			Color tempcolor = new Color();
			ColorUtility.TryParseHtmlString("#" + html_color, out tempcolor);
			GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = tempcolor;
		}
	}


}
