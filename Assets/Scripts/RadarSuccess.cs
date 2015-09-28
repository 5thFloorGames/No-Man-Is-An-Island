using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadarSuccess : MonoBehaviour {

	public Text textElement;
	private string textToModify = "Very good Commander, we have identified the vessel.";
	GameObject controller;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateCanvas() {
		controller = GameObject.FindWithTag ("GameController");
		Threat threat = controller.GetComponent<ResourcesScript> ().getThreat();
		textElement.text = textToModify + "It is " + threat.getName () + ".";
		//  It can probably take around "
		// 	+ threat.getWeaponValue() + " worth of weapons to take it down.";
	}
}
