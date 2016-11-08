using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CPU_load_buttons : MonoBehaviour {

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
		foreach(string name in CPU_Name_Loader.cpu_name_loading.CPU_names) {
			GameObject working_with;
			working_with = Instantiate(button);
			working_with.transform.SetParent(layout);

			working_with.GetComponent<CPU_Send_To_Upgrade>().speed = CPU_Name_Loader.cpu_name_loading.CPU_clock_speed[temp];
			working_with.GetComponent<CPU_Send_To_Upgrade>().cores = CPU_Name_Loader.cpu_name_loading.CPU_cores[temp];
			working_with.GetComponent<CPU_Send_To_Upgrade>().price = CPU_Name_Loader.cpu_name_loading.CPU_price[temp];
			working_with.GetComponent<CPU_Send_To_Upgrade>().object_name = name;
			temp++;
		}
	}
}
