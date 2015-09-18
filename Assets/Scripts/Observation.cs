using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Observation : MonoBehaviour {

	public Text textElement;
	private string textToModify = "Sir, we have an unidentified vessel approaching.\n";
	GameObject controller;
	private string[] speeds = {
		"7",
		"9",
		"12.5",
		"14",
		"16 ⅔",
		"17.8",
		"19",
		"22.4",
		"23",
		"63.51",
		"310.11",
		"-22",
		".07831",
		"4.6i",
		"sqrt(32)",
		"ظصش",
		"indefinite"
	};

	private string[] sizes = {"tiny", "small", "medium", "large", "huge", "gargantuan", "asymmetrical", "closed", "malformed", "unporportionated", "four-dimensional", "indescribable", "anguilliform", "cochleate", "memoryladen"};
	private string[] bearings = {"north", "north-west", "west", "south-west", "south", "south-east", "east", "north-east", "direction unclear", "going in circles", "tangential", "noneuclidean", "towards lower gravity", "unconscious", "indian summer", "past regrets", "memories of a loved one"};

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
