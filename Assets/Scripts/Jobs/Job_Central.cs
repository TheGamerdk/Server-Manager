using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.IO;

public class Job_Central : MonoBehaviour {

	//Where you get your finest quality jobs

	/* Job Offers Table
	 * Element 0: Company Name
	 * Element 1: Job Name
	 * Element 2: CPU Required
	 * Element 3: Storage Required
	 * Element 4: Pay
	 * Element 5: Assigned job offer box
	 */

	public static Job_Central job_centrals;

	public string[] JobOffer1;
	public string[] JobOffer2;
	public string[] JobOffer3;
	public string[] company_names;
	public string[] jobs;

	public int job_offer;

	public GameObject job_detail_panel;
	public GameObject Job_offer_panel;
	public GameObject job1;
	public GameObject job2;
	public GameObject job3;

	public float[] max_cpu;
	public float[] min_cpu;
	public float[] max_storage;
	public float[] min_storage;
	public int[] max_pay;
	public int[] middle_pay;
	public int[] low_pay;

	public bool[] filled_spaces;

	public string[] Accepted1;
	public string[] Accepted2;
	public string[] Accepted3;

	public int JobAmount;


	void Start () {
		if (job_centrals == null) {
			job_centrals = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
		CountJobsXML("Misc/Companies/job.xml");
		company_names = new string[CountLines("/Misc/Companies/companies.txt")];
		jobs = new string[JobAmount];
		max_cpu = new float[JobAmount];
		min_cpu = new float[JobAmount];
		min_storage = new float[JobAmount];
		max_pay = new int[JobAmount];
		middle_pay = new int[JobAmount];
		low_pay = new int[JobAmount];
		max_storage = new float[JobAmount];
		filled_spaces = new bool[3];
		//Obsolete, now handled by XML loading
		//LoadStringsToFloat("/Misc/Companies/job_require_1.txt", max_cpu);
		//LoadStringsToFloat("/Misc/Companies/job_require_2.txt", max_storage);
		LoadStrings("Misc/Companies/companies.txt", company_names);
		JobOffer1 = new string[6];
		JobOffer2 = new string[6];
		JobOffer3 = new string[6]; 
		Accepted1 = new string[JobOffer1.Length];
		Accepted1[0] = "0";
		Accepted2 = new string[JobOffer1.Length];
		Accepted2[0] = "0";
		Accepted3 = new string[JobOffer1.Length];
		Accepted3[0] = "0";

		LoadXMLFile("Misc/Companies/job.xml");
		RandomiseJob(JobOffer1);
		AssignToUI(JobOffer1, 1);
		RandomiseJob(JobOffer2);
		AssignToUI(JobOffer2, 2);
		RandomiseJob(JobOffer3);
		AssignToUI(JobOffer3, 3);
//		GoToDetails(JobOffer1, 1);
	}

	void Update() {
		GetNeeded();
	}

	public void RandomiseJob(string[] job) {
		int company_name_random = Random.Range(0, CountLines("/Misc/Companies/companies.txt"));
		int the_job = Random.Range(0, JobAmount);
		float storage;
		float cpu_power;

		cpu_power = Random.Range(min_cpu[the_job], max_cpu[the_job]);
		storage = Random.Range(min_storage[the_job], max_storage[the_job]);
		cpu_power = Mathf.Round(cpu_power * 100f) / 100f;
		storage = Mathf.Round(storage * 1000f) / 1000f;
		//Never, ever seen this before. But it HAS to get a value assigned when its declared. Do not remove!
		int salary = 0;
		if (storage >= max_storage[the_job]  * 0.5) {
			if (cpu_power >= max_cpu[the_job] * 0.5) {
				salary = Random.Range(middle_pay[the_job], max_pay[the_job]);
			} else {
				salary = Random.Range(low_pay[the_job], middle_pay[the_job]);
			}
		} else {
			salary = Random.Range(low_pay[the_job], middle_pay[the_job]);
		}
		job[0] = company_names[company_name_random];
		job[1] = jobs[the_job];
		job[2] = cpu_power.ToString();
		job[3] = storage.ToString();
		job[4] = salary.ToString();
		if (filled_spaces[0] == false) {
			job1.SetActive(true);
			AssignToUI(job, 1);
			filled_spaces[0] = true;
			job[5] = "1";
		} else if (filled_spaces[1] == false) {
			job2.SetActive(true);
			AssignToUI(job, 2);
			filled_spaces[1] = true;
			job[5] = "2";
		} else {
			job3.SetActive(true);
			AssignToUI(job, 3);
			filled_spaces[2] = true;
			job[5] = "3";
		}
	}

	public void GetNeeded() {
		float temp = 0;
		float temp2 = 0;
		float temp3 = 0;
		float temp4 = 0;
		float temp5 = 0;
		float temp6 = 0;
		if (Accepted1[0] != "") {
			float.TryParse(Accepted1[3], out temp);
		}
		if (Accepted2[0] != "") {
			float.TryParse(Accepted2[3], out temp2);
		}
		if (Accepted2[0] != "") {
			float.TryParse(Accepted3[3], out temp3);
		}
		if (Accepted1[0] != "") {
			float.TryParse(Accepted1[4], out temp4);
		}
		if (Accepted2[0] != "") {
			float.TryParse(Accepted2[4], out temp5);
		}
		if (Accepted2[0] != "") {
			float.TryParse(Accepted3[4], out temp6);
		}
		Server_Data.server_dat.needed_speed = temp + temp2 + temp3;
		Server_Data.server_dat.needed_space = temp4 + temp5 + temp6;
	}
		
	void UpdateUI() {
		if (JobOffer1[5] == "1") {
			AssignToUI(JobOffer1, 1);
		} else if (JobOffer1[5] == "2") {
			AssignToUI(JobOffer1, 2);
		} else if (JobOffer1[5] == "3") {
			AssignToUI(JobOffer1, 3);
		}
		if (JobOffer2[5] == "1") {
			AssignToUI(JobOffer2, 1);
		} else if (JobOffer2[5] == "2") {
			AssignToUI(JobOffer2, 2);
		} else if (JobOffer2[5] == "3") {
			AssignToUI(JobOffer2, 3);
		}
		if (JobOffer3[5] == "1") {
			AssignToUI(JobOffer3, 1);
		} else if (JobOffer3[5] == "2") {
			AssignToUI(JobOffer3, 2);
		} else if (JobOffer3[5] == "3") {
			AssignToUI(JobOffer3, 3);
		}
		if (filled_spaces[0] == false) {
			job1.SetActive(false);
		} 
		if (filled_spaces[1] == false) {
			job2.SetActive(false);
		}
		if (filled_spaces[2] == false) {
			job3.SetActive(false);
		} 

	}

	// Update is called once per frame

	void AssignToUI(string[] array, int offer) {
		Job_offer_panel.SetActive(true);
		GameObject.Find("From_Text_" + offer).GetComponent<Text>().text = "Job offer from" + "\n" + array[0];
		GameObject.Find("Job_Text_" + offer).GetComponent<Text>().text = "They want:" + "\n" + array[1];
		GameObject.Find("CPU_Text_" + offer).GetComponent<Text>().text = "They request " + array[2] + "Ghz of CPU Power";
		float temp = 0; 
		float.TryParse(array[3], out temp);
		if (temp >= 1) {
			GameObject.Find("Storage_Text_" + offer).GetComponent<Text>().text = "They also request " + array[3] + "GB of storage";
		} else {
			GameObject.Find("Storage_Text_" + offer).GetComponent<Text>().text = "They also request " + temp * 1000 + "MB of storage";
		}
		GameObject.Find("Pay_Text_" + offer).GetComponent<Text>().text = "They will pay " + array[4] + "$ per week";
		Job_offer_panel.SetActive(false);
	}

	public void GoToDetails(string[] array, int offer) {
		job_detail_panel.SetActive(true);
		GameObject.Find("Review_Text").GetComponent<Text>().text = "Currently reviewing offer from " + array[0];
		GameObject.Find("Job_Detail_Text").GetComponent<Text>().text = "They want " + array[1];
		GameObject.Find("CPU_Detail_Text").GetComponent<Text>().text = "CPU Power Needed" + "\n" + array[2] + "Ghz";
		float temp = 0; 
		float.TryParse(array[3], out temp);
		if (temp >= 1) {
			GameObject.Find("Storage_Detail_Text").GetComponent<Text>().text = "Storage Needed " + "\n" + array[3] + "GB of storage";
		} else {
			GameObject.Find("Storage_Detail_Text").GetComponent<Text>().text = "Storage Needed " + "\n" + temp * 1000 + "MB of storage";
		}
		GameObject.Find("Pay_Detail_Text").GetComponent<Text>().text = "Their payment will be " + "\n" + array[4] + "$ per week";
		job_offer = offer;
	} 

	public void AcceptOfferButtonBypass() {
		if (job_offer == 1) {
			AcceptOffer(JobOffer1);
		} else if (job_offer == 2) {
			AcceptOffer(JobOffer2);
		} else {
			AcceptOffer(JobOffer3);
		}
	} 

	void AcceptOffer(string[] array) {
		float convertTemp;
		float.TryParse(array[2], out convertTemp);
		float convertTemp2;
		float.TryParse(array[3], out convertTemp2);
		if(Server_Data.server_dat.needed_speed + convertTemp > Server_Data.server_dat.combined_speed) {
			job_detail_panel.SetActive(false);
			print("Not enough CPU!");
			return;
		}
		if(Server_Data.server_dat.needed_space + convertTemp2 > Server_Data.server_dat.combined_storage) {
			job_detail_panel.SetActive(false);
			print("Not enough storage!!");
			return;
		}
		if (Accepted1[0] == "0") {
				for(int i = 0; i < array.Length - 1; i++) {
					Accepted1[i + 1] = array[i];
				}
				Accepted1[0] = "1";
				if (array[5] == "1") {
					filled_spaces[0] = false;
				} else if (array[5] == "2") {
					filled_spaces[1] = false;
				} else {
					filled_spaces[2] = false;
				}
			for(int i = 0; i < array.Length; i++) {
				array[i] = null;
			}
			Server_Data.server_dat.AssignCapacity();
			UpdateUI();
		} else if (Accepted2[0] == "0") {
				for(int i = 0; i < array.Length - 1; i++) {
					Accepted2[i + 1] = array[i];
				}
				Accepted2[0] = "1";
				if (array[5] == "1") {
					filled_spaces[0] = false;
				} else if (array[5] == "2") {
					filled_spaces[1] = false;
				} else {
					filled_spaces[2] = false;
				}
			for(int i = 0; i < array.Length; i++) {
				array[i] = null;
			}
			Server_Data.server_dat.AssignCapacity();
				UpdateUI();
		} else if (Accepted3[0] == "0") {
				for(int i = 0; i < array.Length - 1; i++) {
					Accepted3[i + 1] = array[i];
				}
				Accepted3[0] = "1";
				if (array[5] == "1") {
					filled_spaces[0] = false;
				} else if (array[5] == "2") {
					filled_spaces[1] = false;
					} else {
					filled_spaces[2] = false;
				}
			for(int i = 0; i < array.Length; i++) {
				array[i] = null;
			}
			Server_Data.server_dat.AssignCapacity();
				UpdateUI();
		}
		//Remember to come back here for upgrade requirement for Accepted4 and Accepted 5
		print("Not active");
		if (JobOffer1[0] == null) {
			if (JobOffer2[0] == null) {
				if (JobOffer3[0] == null) {
					Job_offer_panel.SetActive(false);
				}
			}
		}
		job_detail_panel.SetActive(false);
	}

	public void DecideLater() {
		job_detail_panel.SetActive(false);
	}

	//Loading of various kinds here!
	void LoadStrings(string path, string[] array) {
		string local_path;
		local_path = null;
		print("Company Loader: This should be empty: " + local_path);

		// Company Name Loading starts here

		local_path = System.IO.Path.GetFullPath("./") + path;
		print("Company Loader: Currently loaded Path: " + local_path);
		StreamReader reader = new StreamReader(local_path);
		for (int i = 0; i < array.Length; i++) {
			array[i] = reader.ReadLine();

		}
		reader.Close();
	}

	void LoadStringsToFloat(string path, float[] array) {
		string local_path;
		local_path = null;
		print("Company Loader: This should be empty: " + local_path);

		// Company Name Loading starts here

		local_path = System.IO.Path.GetFullPath("./") + path;
		print("Company Loader: Currently loaded Path: " + local_path);
		StreamReader reader = new StreamReader(local_path);
		for (int i = 0; i < array.Length; i++) {
			string temp = reader.ReadLine();
			float temp2;
			float.TryParse(temp, out temp2);
			array[i] = temp2;
		}
		reader.Close();
	}

	int CountLines(string path) {
		string local_path;
		int lenght_of_file = 0;
		local_path = Application.dataPath + path;
		StreamReader reader = new StreamReader(local_path);
		while(reader.ReadLine() != null) {
			lenght_of_file++;
		}
		reader.Close();
		return lenght_of_file;
	}

	void LoadXMLFile(string path) {
		XmlDocument xmlfile = new XmlDocument();
		xmlfile.Load(Path.GetFullPath("./") + path);
		XmlNodeList joblist = xmlfile.GetElementsByTagName("job");

		int JobNumber = 0;

		foreach(XmlNode jobinfo in joblist) {
			XmlNodeList content = jobinfo.ChildNodes;
			foreach (XmlNode under_nodes in content) {
				
				if(under_nodes.Name == "lowest_pay") {
					int.TryParse(under_nodes.InnerText, out low_pay[JobNumber]);
				}
				if (under_nodes.Name == "middle_pay") {
					int.TryParse(under_nodes.InnerText, out middle_pay[JobNumber]);
				}
				if(under_nodes.Name == "max_pay") {
					int.TryParse(under_nodes.InnerText, out max_pay[JobNumber]);
				}
				if(under_nodes.Name == "cpu_max") {
					float.TryParse(under_nodes.InnerText, out max_cpu[JobNumber]);
				}
				if (under_nodes.Name == "storage_max") {
					float.TryParse(under_nodes.InnerText, out max_storage[JobNumber]);
				}
				if (under_nodes.Name == "job_name") {
					jobs[JobNumber] = under_nodes.InnerText;
				}
				if (under_nodes.Name == "cpu_min") {
					float.TryParse(under_nodes.InnerText, out min_cpu[JobNumber]);
				}
				if (under_nodes.Name == "storage_min") {
					float.TryParse(under_nodes.InnerText, out min_storage[JobNumber]);
				}
			}
			JobNumber++;
		}
	}

	void CountJobsXML(string path) {
		XmlDocument xmlfile = new XmlDocument();
		xmlfile.Load(Path.GetFullPath("./") + path);
		XmlNodeList joblist = xmlfile.GetElementsByTagName("info");

		int Number = 0;

		foreach(XmlNode jobinfo in joblist) {
			XmlNodeList content = jobinfo.ChildNodes;
			foreach (XmlNode under_nodes in content) {

				if (under_nodes.Name == "amount") {
					int.TryParse(under_nodes.InnerText, out Number);
				}

			}
		}
		JobAmount = Number;
	}
}