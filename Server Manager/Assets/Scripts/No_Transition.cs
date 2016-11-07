using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class No_Transition : MonoBehaviour {

	public Sprite sprite_with_transtion;


	void Start () {
	
	}
	

	void Update () {
		if (gameObject.GetComponent<Image>().sprite != sprite_with_transtion) {
			gameObject.GetComponent<Button>().transition = Selectable.Transition.None;
		} else {
			gameObject.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
			transform.GetChild(0).gameObject.SetActive(true);
		}
	}


}
