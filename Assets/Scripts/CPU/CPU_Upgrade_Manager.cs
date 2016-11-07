using UnityEngine;
using System.Collections;

public class CPU_Upgrade_Manager : MonoBehaviour {

	public GameObject serving;

	public GameObject panel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BuyCPU(float new_speed, int new_cores, int new_price) {
		if (serving.GetComponent<CPU_local_manager>().speed != 0) {
			serving.GetComponent<CPU_local_manager>().EmptyOwnCapacity();
		}
		serving.GetComponent<CPU_local_manager>().speed = new_speed;
		serving.GetComponent<CPU_local_manager>().cores = new_cores;
		if (Company_Data.company_dat.money - new_speed < 0) {
			return;
		} else {
			Company_Data.company_dat.money -= new_price;
		}
		serving.GetComponent<CPU_local_manager>().PushToCentral();
		serving.GetComponent<CPU_local_manager>().HasCPU = true;
		panel.SetActive(false);
	}
}
