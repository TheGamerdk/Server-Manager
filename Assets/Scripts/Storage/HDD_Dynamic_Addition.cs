using UnityEngine;
using System.Collections;

public class HDD_Dynamic_Addition : MonoBehaviour {

	public GameObject button;
	public Transform layout;
	public GameObject layout_object;

	// Use this for initialization
	void Awake () {
		layout = layout_object.GetComponent<RectTransform>();
		LoadButtons();

	}

	// Update is called once per frame
	void Update () {

	}

	void LoadButtons() {
		int temp = 0;
		foreach(string name in HDD_Name_Loader.hdd_name_loading.HDD_names) {
			GameObject working_with;
			working_with = Instantiate(button);
			working_with.transform.SetParent(layout);

			working_with.GetComponent<HDD_Send_To_Upgrade>().space = HDD_Name_Loader.hdd_name_loading.HDD_amount[temp];
			working_with.GetComponent<HDD_Send_To_Upgrade>().price = HDD_Name_Loader.hdd_name_loading.HDD_price[temp];
			working_with.GetComponent<HDD_Send_To_Upgrade>().object_name = name;
			temp++;
		}
	}
}
