using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.IO;

public class HDD_Name_Loader : MonoBehaviour {

	public static HDD_Name_Loader hdd_name_loading;

	public string[] HDD_names;
	public int[] HDD_amount;
	public int[] HDD_price;
	public int lenght_of_file;

	// Use this for initialization
	void Awake () {
		CountXMLFile("Hardware/hardware.xml");
		HDD_names = new string[lenght_of_file];
		HDD_amount = new int[lenght_of_file];
		HDD_price = new int[lenght_of_file];
		LoadDataFile("Hardware/hardware.xml");
		if (hdd_name_loading == null) {
			hdd_name_loading = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	void CountXMLFile(string path) {
		XmlDocument xmlfile = new XmlDocument();
		xmlfile.Load(System.IO.Path.GetFullPath("./") + path);
		XmlNodeList joblist = xmlfile.GetElementsByTagName("hdd");

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
		XmlNodeList joblist = xmlfile.GetElementsByTagName("hdd");

		int Number = 0;

		foreach(XmlNode jobinfo in joblist) {
			XmlNodeList content = jobinfo.ChildNodes;

			foreach (XmlNode nodes in content) {
				if (nodes.Name == "name") {
					HDD_names[Number] = nodes.InnerText;
				} else if (nodes.Name == "storage_amount") {
					int.TryParse(nodes.InnerText, out HDD_amount[Number]);
				} else if (nodes.Name == "price") {
					int.TryParse(nodes.InnerText, out HDD_price[Number]);
				}
			}
			Number++;
		}
	}
}
