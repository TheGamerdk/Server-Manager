using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CPU_local_manager : MonoBehaviour {

	public bool HasCPU;

	public float speed;
	public int cores;
	public float combined;

	public Sprite cpu;

	// Use this for initialization
	void Awake () {
		PushToCentral();
	}
	
	// Update is called once per frame
	void Update () {
		if (HasCPU == true) {
			gameObject.GetComponent<Image>().sprite = cpu;
			if (cores == 1) {
				gameObject.GetComponentInChildren<Text>().text = speed + "Ghz" + "\n" + cores + "Core";
			} else {
				gameObject.GetComponentInChildren<Text>().text = speed + "Ghz" + "\n" + cores + "Cores";
			}
		}


	}
	// No need to try to fix this quite now
	/*void GetTotal() {
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

	}
	*/

	public void PushToCentral() {
		Server_Data.server_dat.combined_speed += speed*cores;
		Server_Data.server_dat.AssignCapacity();
	}

	public void EmptyOwnCapacity() {
		Server_Data.server_dat.combined_speed -= speed*cores;
	}
}
