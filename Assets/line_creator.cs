using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class line_creator : MonoBehaviour {

	public GameObject originobject;
	public GameObject targetobject;

	public GameObject prefab;

	public float thickness;

	// Use this for initialization
	void Start () {
		DrawLine(originobject, targetobject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DrawLine(GameObject origin, GameObject target) {
		if (thickness != 5) {
			Debug.LogWarning("Warning! Line creator has detected a thickness of higher than or lower than 5. This will not work well!");
		}
		float distance = (origin.GetComponent<RectTransform>().anchoredPosition.x + target.GetComponent<RectTransform>().anchoredPosition.x)/2;
		float width = origin.GetComponent<RectTransform>().anchoredPosition.x - target.GetComponent<RectTransform>().anchoredPosition.x;

		if (origin.transform.position.y == target.transform.position.y) {
			GameObject line = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
			line.transform.SetParent(GameObject.Find("Content_Upgrades").transform);
			line.transform.SetSiblingIndex(0);
			line.GetComponent<RectTransform>().anchoredPosition = new Vector2(distance, origin.GetComponent<RectTransform>().anchoredPosition.y);
			line.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Abs(width), thickness);
		} else {
			distance = distance / 2;
			GameObject line1 = Instantiate(prefab, new Vector3(0,0,0), Quaternion.Euler(0,0,0)) as GameObject;
			line1.transform.SetParent(GameObject.Find("Content_Upgrades").transform);
			line1.transform.SetSiblingIndex(0);
			line1.GetComponent<RectTransform>().anchoredPosition = new Vector2(distance+origin.GetComponent<RectTransform>().anchoredPosition.x/2, origin.GetComponent<RectTransform>().anchoredPosition.y);
			line1.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Abs(width)/2, thickness);
			GameObject line2 = Instantiate(prefab, new Vector3(0,0,0), Quaternion.Euler(0,0,0)) as GameObject;
			line2.transform.SetParent(GameObject.Find("Content_Upgrades").transform);
			line2.transform.SetSiblingIndex(0);
			line2.GetComponent<RectTransform>().anchoredPosition = new Vector2(distance+target.GetComponent<RectTransform>().anchoredPosition.x/2, target.GetComponent<RectTransform>().anchoredPosition.y);
			line2.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Abs(width)/2, thickness);
			GameObject line3 = Instantiate(prefab, new Vector3(0,0,0), Quaternion.Euler(0,0,0)) as GameObject;
			float y_distance = (origin.GetComponent<RectTransform>().anchoredPosition.y + target.GetComponent<RectTransform>().anchoredPosition.y)/2;
			float y_width = origin.GetComponent<RectTransform>().anchoredPosition.y - target.GetComponent<RectTransform>().anchoredPosition.y;
			distance = (line1.GetComponent<RectTransform>().anchoredPosition.x + line2.GetComponent<RectTransform>().anchoredPosition.x)/2;
			line3.transform.SetParent(GameObject.Find("Content_Upgrades").transform);
			line3.transform.SetSiblingIndex(0);
			line3.GetComponent<RectTransform>().sizeDelta = new Vector2(thickness, Mathf.Abs(y_width));
			line3.GetComponent<RectTransform>().anchoredPosition = new Vector2(distance, y_distance);
			line3.GetComponent<RectTransform>().sizeDelta = new Vector2(thickness, Mathf.Abs(y_width));
		}
	}
}
