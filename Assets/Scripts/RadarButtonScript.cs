using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RadarButtonScript : MonoBehaviour {

	public List<Button> buttons;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateCanvas(){
		int radars = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ResourcesScript> ().getRadars ();
		for (int i = 0; i <= radars; i++) {
			buttons[i].interactable = true;
		}
	}
}