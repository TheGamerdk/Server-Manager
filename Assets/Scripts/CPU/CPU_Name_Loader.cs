using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.IO;

public class CPU_Name_Loader : MonoBehaviour {

	public static CPU_Name_Loader cpu_name_loading;

	public string[] CPU_names;
	public float[] CPU_clock_speed;
	public int[] CPU_cores;
	public int[] CPU_price;
	public int lenght_of_file;

	// Use this for initialization
	void Awake () {
		CountXMLFile("Hardware/hardware.xml");
		CPU_names = new string[lenght_of_file];
		CPU_clock_speed = new float[lenght_of_file];
		CPU_cores = new int[lenght_of_file];
		CPU_price = new int[lenght_of_file];
		//LoadFiles();
		LoadDataFile("Hardware/hardware.xml");
		if (cpu_name_loading == null) {
			cpu_name_loading = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
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

		path = System.IO.Path.GetFullPath("./") + "Hardware/CPU/cpu.txt";
		print("CPU Loader: Currently loaded Path: " + path);
		StreamReader reader = new StreamReader(path);
		for (int i = 0; i < CPU_names.Length; i++) {
			CPU_names[i] = reader.ReadLine();

		}
		reader.Close();

		// CPU Clock Speed Loading starts here

		path = System.IO.Path.GetFullPath("./")+ "Hardware/CPU/cpu_clock.txt";
		print("CPU Loader: Currently loaded Path: " + path);
		StreamReader reader2 = new StreamReader(path);
		for (int i = 0; i < CPU_clock_speed.Length; i++) {
			float result;
			float.TryParse(reader2.ReadLine(), out result);
			CPU_clock_speed[i] = result; 
		}

	}

	//Gets amount of lines in CPU name file only! Meaning no CPU without names

	/*int GetLineCount() {
		string path;
		lenght_of_file = 0;
		path = Application.dataPath + "/Hardware/CPU/cpu.txt";
		StreamReader reader = new StreamReader(path);
		while(reader.ReadLine() != null) {
			lenght_of_file++;
		}
		reader.Close();
		return lenght_of_file;
	} */


	void CountXMLFile(string path) {
		XmlDocument xmlfile = new XmlDocument();
		xmlfile.Load(System.IO.Path.GetFullPath("./") + path);
		XmlNodeList joblist = xmlfile.GetElementsByTagName("cpu");

		foreach(XmlNode jobinfo in joblist) {
			XmlNodeList content = jobinfo.ChildNodes;
			foreach (XmlNode under_nodes in content) {

				if (under_nodes.Name == "name") {
					lenght_of_file++;
				}
			}
		}
	}

	void LoadDataFile(string path) {
		XmlDocument xmlfile = new XmlDocument();
		xmlfile.Load(System.IO.Path.GetFullPath("./") + path);
		XmlNodeList joblist = xmlfile.GetElementsByTagName("cpu");

		int Number = 0;

		foreach(XmlNode jobinfo in joblist) {
			XmlNodeList content = jobinfo.ChildNodes;

			foreach (XmlNode nodes in content) {
				if (nodes.Name == "name") {
					CPU_names[Number] = nodes.InnerText;
				} else if (nodes.Name == "clock_speed") {
					float.TryParse(nodes.InnerText, out CPU_clock_speed[Number]);
				} else if (nodes.Name == "cores") {
					int.TryParse(nodes.InnerText, out CPU_cores[Number]);
				} else if (nodes.Name == "price") {
					int.TryParse(nodes.InnerText, out CPU_price[Number]);
				}
			}
			Number++;
		}
	}
}
