using UnityEngine;
using System.Collections;

public class HDD_Upgrade_Manager : MonoBehaviour {

	public GameObject serving;

	public GameObject panel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BuyHDD(int cost, float space) {
		if (serving.GetComponent<HDD_local_manager>().amount != 0) {
			serving.GetComponent<HDD_local_manager>().EmptyOwnCapacity();
		}
		serving.GetComponent<HDD_local_manager>().amount = space;
		if (Company_Data.company_dat.money - cost < 0) {
			return;
		} else {
			Company_Data.company_dat.money -= cost;
		}
		serving.GetComponent<HDD_local_manager>().PushToCentral();
		serving.GetComponent<HDD_local_manager>().HasHDD = true;
		panel.SetActive(false);
	}
}
