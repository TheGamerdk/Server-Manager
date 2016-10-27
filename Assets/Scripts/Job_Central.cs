using UnityEngine;
using System.Collections;
using System.IO;

public class Job_Central : MonoBehaviour {

	//Where you get your finest quality jobs

	public string[] JobOffer1;
	public string[] company_names;
	public string[] jobs;

	void Start () {
		company_names = new string[CountLines("/Misc/Companies/companies.txt")];
		jobs = new string[CountLines("Misc/Companies/jobs.txt")];
		LoadStrings("/Misc/Companies/companies.txt", company_names);
		JobOffer1 = new string[2];
		RandomiseJob(JobOffer1);
	}

	void RandomiseJob(string[] job) {
		int company_name_random = Random.Range(1, CountLines("/Misc/Companies/companies.txt"));
		print(company_name_random);
		job[0] = company_names[company_name_random];
		//job[1] = 
	}




	// Update is called once per frame
	void Update () {
		
	}



	void LoadStrings(string path, string[] array) {
		string local_path;
		local_path = null;
		print("Company Loader: This should be empty: " + local_path);

		// Company Name Loading starts here

		local_path = Application.dataPath + path;
		print("Company Loader: Currently loaded Path: " + local_path);
		StreamReader reader = new StreamReader(local_path);
		for (int i = 0; i < array.Length; i++) {
			array[i] = reader.ReadLine();

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
}
