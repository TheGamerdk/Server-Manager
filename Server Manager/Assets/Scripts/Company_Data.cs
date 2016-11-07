using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Company_Data : MonoBehaviour {

	public static Company_Data company_dat;
	public int money;


	// Use this for initialization
	void Awake () {
		//Insure no multiple Company Databases are present
		if (company_dat == null) {
			company_dat = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		} 
	}

	
	// Update Money counter
	void Update () {
		GameObject.Find("Money_Text").GetComponent<Text>().text = "Money: " + money + "$";
	}
}
