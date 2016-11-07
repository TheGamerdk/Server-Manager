using UnityEngine;
using System.Collections;

public class KeepCPUEnabled : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<CPU_local_manager>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
