using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WeaponButtonScript : MonoBehaviour {

	public List<Button> buttons;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateCanvas(){
		int weapons = Mathf.Min(GameObject.FindGameObjectWithTag ("GameController").GetComponent<ResourcesScript> ().getWeapons(),3);

		for (int i = 0; i < buttons.Count; i++) {
			buttons[i].interactable = true;
		}
		if (weapons < 3) {
			for (int i = weapons + 1; i < buttons.Count; i++) {
				buttons[i].interactable = false;
			}
		}
	}
}
