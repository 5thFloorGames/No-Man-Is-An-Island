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
		int radars = Mathf.Min(GameObject.FindGameObjectWithTag ("GameController").GetComponent<ResourcesScript> ().getRadars (),3);
		for (int i = 0; i <= radars; i++) {
			buttons[i].interactable = true;
		}
	}
}