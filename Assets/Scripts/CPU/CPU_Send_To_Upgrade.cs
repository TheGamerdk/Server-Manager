using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CPU_Send_To_Upgrade : MonoBehaviour {

	public string name;

	public float speed;
	public int cores;
	public int price;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponentInChildren<Text>().text = name + "\n" + speed + " Ghz" + "\n" + cores + " Core(s)" + "\n" + price + "$";
	}

	public void Send() {
		GameObject.Find("CPU_Upgrade").GetComponent<CPU_Upgrade_Manager>().BuyCPU(speed, cores, price);
	}
}
