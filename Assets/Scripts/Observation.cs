using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Observation : MonoBehaviour {

	public Text textElement;
	private string textToModify = "Sir, we have an unidentified vessel approaching.\n";
	GameObject controller;
	private string[] speeds = {
		"9.0",
		"6.1",
		"16.5",
		"11 ⅔",
		"19.8",
		"0000.23",
		"63.51",
		"-310.11",
		".07831",
		"4.6i",
		"sqrt(32)",	
		"ظصش",

		"indefinite"
	};

	private string[] sizes = {"medium", "negliable", "small", "large", "closed", "gargantuan", "asymmetrical", "malformed","four-dimensional", "indescribable", "anguilliform", "noneuclidean", "memoryladen"};
	private string[] bearings = {"north", "north-west", "west", "south-west", "south-east", "north-east", "direction unclear", "going in circles", "tangential", "memories of a loved one", "unconsciousness", "backwards in time", "towards space"};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateCanvas() {
		controller = GameObject.FindWithTag ("GameController");
		Threat threat = controller.GetComponent<ResourcesScript> ().getThreat();
		textElement.text = textToModify + "\nBearing: " + RandomValue(bearings) + "\nSpeed: " 
			+ RandomValue(speeds) + "\nDescription: " + RandomValue(sizes);
	}

	private string RandomValue(string[] array){
		// bound by sanity
		return array [Random.Range (0, 5)];
	}
}
