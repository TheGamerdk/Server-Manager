using UnityEngine;
using System.Collections;

public class CPU_local_manager : MonoBehaviour {

	public float speed;
	public int cores;
	public float combined;

	// Use this for initialization
	void Awake () {
		PushToCentral();
	}
	
	// Update is called once per frame
	void Update () {
		


	}
		void GetTotal() {
		if (cores == 1) {
			combined = speed * cores;
		} else {
			float core_to_reduce_by = cores - 1;
			float reduce_by = 1 - core_to_reduce_by / 10;
			print(reduce_by);
			if (reduce_by > 1) {
				combined = speed * cores / reduce_by;
				print("divide");
			} else {
				combined = speed * cores * reduce_by;
			}
		}
		if (cores > 10) {
			cores = 10 ;
		}
	}

	void PushToCentral() {
		Server_Data.server_dat.combined_speed += speed*cores;
		Server_Data.server_dat.AssignCapacity();
	}


}
