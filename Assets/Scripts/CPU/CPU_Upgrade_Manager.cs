using UnityEngine;
using System.Collections;

public class CPU_Upgrade_Manager : MonoBehaviour {

	public GameObject serving;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BuyCPU(float new_speed, int new_cores) {
		if (serving.GetComponent<CPU_local_manager>().speed != 0) {
			serving.GetComponent<CPU_local_manager>().EmptyOwnCapacity();
		}
		serving.GetComponent<CPU_local_manager>().speed = new_speed;
		serving.GetComponent<CPU_local_manager>().cores = new_cores;
		serving.GetComponent<CPU_local_manager>().PushToCentral();
	}
}
