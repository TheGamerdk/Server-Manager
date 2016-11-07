using UnityEngine;
using System.Collections;
using System.IO;

public class CPU_Name_Loader : MonoBehaviour {

	public string[] CPU_names;
	public float[] CPU_clock_speed;
	private int lenght_of_file;

	// Use this for initialization
	void Awake () {
		CPU_names = new string[GetLineCount()];
		CPU_clock_speed = new float[GetLineCount()];
		LoadFiles();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadFiles() {
		// Setup for whole function
		string path;
		path = null;
		print("CPU Loader: This should be empty: " + path);

		// CPU Name Loading starts here

		path = Application.dataPath + "/Hardware/CPU/cpu.txt";
		print("CPU Loader: Currently loaded Path: " + path);
		StreamReader reader = new StreamReader(path);
		for (int i = 0; i < CPU_names.Length; i++) {
			CPU_names[i] = reader.ReadLine();

		}
		reader.Close();

		// CPU Clock Speed Loading starts here

		path = Application.dataPath + "/Hardware/CPU/cpu_clock.txt";
		print("CPU Loader: Currently loaded Path: " + path);
		StreamReader reader2 = new StreamReader(path);
		for (int i = 0; i < CPU_clock_speed.Length; i++) {
			float result;
			float.TryParse(reader2.ReadLine(), out result);
			CPU_clock_speed[i] = result; 
		}

	}

	//Gets amount of lines in CPU name file only! Meaning no CPU without names

	int GetLineCount() {
		string path;
		lenght_of_file = 0;
		path = Application.dataPath + "/Hardware/CPU/cpu.txt";
		StreamReader reader = new StreamReader(path);
		while(reader.ReadLine() != null) {
			lenght_of_file++;
		}
		reader.Close();
		return lenght_of_file;
	}
}
