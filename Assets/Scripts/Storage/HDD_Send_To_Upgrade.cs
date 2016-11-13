using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HDD_Send_To_Upgrade : MonoBehaviour {

	public string object_name;
	public int price;
	public float space;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponentInChildren<Text>().text = object_name + "\n" + space + " GB" + "\n" + price + "$";
	}

	public void Send() {
		GameObject.Find("HDD_Upgrade").GetComponent<HDD_Upgrade_Manager>().BuyHDD(price, space);
	}
}
