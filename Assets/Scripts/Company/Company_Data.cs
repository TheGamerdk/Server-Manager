using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Company_Data : MonoBehaviour {

	public static Company_Data company_dat;
	public int money;
	public int weeknum;
	public string[] months;
	public int monthnum;


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
		if (weeknum == 5) {
			monthnum++;
			weeknum = 1;
		}
		if (monthnum == 12) {
			monthnum = 0;
		}
		GameObject.Find("Date_Text").GetComponent<Text>().text = "Week " + weeknum + " of " + months[monthnum];
		GameObject.Find("Money_Text").GetComponent<Text>().text = "Money: " + money + "$";
	}
}
