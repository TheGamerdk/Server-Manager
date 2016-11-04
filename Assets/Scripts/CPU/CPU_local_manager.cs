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
			float core_reduce_by = cores - 1;
			float reduce_by = 1 - core_reduce_by / 10;
			if (reduce_by >= 1) {
				combined = speed * cores / reduce_by;
			} else {
				combined = speed * cores * reduce_by;
			}
			

		}
			

	}

	public void PushToCentral() {
		Server_Data.server_dat.combined_speed += speed*cores;
		Server_Data.server_dat.AssignCapacity();
	}

	public void EmptyOwnCapacity() {
		Server_Data.server_dat.combined_speed -= speed*cores;
	}
}
