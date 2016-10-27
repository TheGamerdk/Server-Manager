using UnityEngine;
using System.Collections;
using System.IO;

public class Job_Central : MonoBehaviour {

	//Where you get your finest quality jobs

	public string[] JobOffer1;
	public string[] company_names;

	void Start () {
		company_names = new string[CountCompanyNames()];
		LoadCompanyNames();
		JobOffer1 = new string[2];
		RandomiseJob(JobOffer1);

	}

	void RandomiseJob(string[] job) {
		int company_name_random = Random.Range(1, CountCompanyNames());
		print(company_name_random);
		job[0] = company_names[company_name_random];
	}


	// Update is called once per frame
	void Update () {
	
	}



	void LoadCompanyNames() {
		string path;
		path = null;
		print("Company Loader: This should be empty: " + path);

		// Company Name Loading starts here

		path = Application.dataPath + "/Misc/Companies/companies.txt";
		print("Company Loader: Currently loaded Path: " + path);
		StreamReader reader = new StreamReader(path);
		for (int i = 0; i < company_names.Length; i++) {
			company_names[i] = reader.ReadLine();

		}
		reader.Close();
	}

	int CountCompanyNames() {

		string path;
		int lenght_of_file = 0;
		path = Application.dataPath + "/Misc/Companies/companies.txt";
		StreamReader reader = new StreamReader(path);
		while(reader.ReadLine() != null) {
			lenght_of_file++;
		}
		reader.Close();
		return lenght_of_file;
	}
}
