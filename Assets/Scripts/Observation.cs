using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Observation : MonoBehaviour {

	public Text textElement;
	private string textToModify = "Sir, we have an unidentified vessel approaching.\n";
	GameObject controller;
	private string[] speeds = {
		"9.0 knots",
		"6.1 knots",
		"16.5 knots",
		"11 ⅔ knots",
		"19.8 knots",
		"0000.23 knotws",
		"63.51 knots",
		"-310.11 knots",
		".07831 knots",
		"4.6i knots",
		"sqrt(32) knots",	
		"ظصش",

		"indefinite"
	};

	private string[] sizes = {
		"our radars suggest the target is rather negliable", 
		"the target appears to be of medium-size", 
		"the target shows as rather small in our radars", 
		"the target appears rather significant in size", 
		"our radars indicate the target is of gargantuan porportions", 
		"the target appears asymmetrical and unpredictable", 
		"the target appears to malformed by emotions, especially guilt",
		"our radars indicate the target has an additional dimension", 
		"our radar-report suggests the target is indescribable",  
		"the nature of the target seems noneuclidean, and it has its own consciousness",
		"the target is heavily laden with memories",
		"the target appears to be you, Sir", 
		"please, make it go away..."
	};
	private string[] bearings = {"north", "north-west", "west", "south-west", "south-east", "north-east", "direction unclear", "going in circles", "tangential", "memories of a loved one", "unconsciousness", "backwards in time", "towards infinity"};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateCanvas() {
		controller = GameObject.FindWithTag ("GameController");
		Threat threat = controller.GetComponent<ResourcesScript> ().getThreat();
		int sanity =  controller.GetComponent<ResourcesScript> ().getSanityLevel();
		textElement.text = textToModify + "\nBearing: " + RandomBearing(sanity) + "\nSpeed: " 
			+ RandomSpeed(sanity) + "\nDescription: " + RandomSize(sanity);
	}

	private string RandomSpeed(int sanity){
		return speeds[Random.Range((0 + sanity), (5 + sanity))];
	}

	private string RandomBearing(int sanity){
		return bearings[Random.Range((0 + sanity), (5 + sanity))];
	}
	
	private string RandomSize(int sanity){
		return sizes[Random.Range((0 + sanity), (5 + sanity))];
	}

	private string RandomValue(string[] array){
		// bound by sanity

		return array [Random.Range (0, 5)];
	}
}
