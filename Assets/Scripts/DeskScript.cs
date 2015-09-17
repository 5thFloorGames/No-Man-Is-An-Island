using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DeskScript : MonoBehaviour {

	public List<Button> buttons;
	public List<Button> activatableOnThreat;
	public Button phone;
	public Button computer;
	public List<GameObject> items;
	// buttonState?

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TurnButtonsOn(){
		foreach(Button b in buttons){
			b.interactable = true;
		}
		bool phoneActive = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CanvasChanger> ().eventsInPhone();
		phone.interactable = phoneActive;
	}

	public void TurnButtonsOff(){
		foreach(Button b in buttons){
			b.interactable = false;
		}
	}

	public void HideThreatButtons(){
		foreach(Button b in activatableOnThreat){
			b.interactable = false;
		}
	}

	public void SetButtonsActive(){
		foreach(Button b in activatableOnThreat){
			b.interactable = true;
		}
	}

	public void HayesOut(){
		activatableOnThreat [0].interactable = false;
	}

	public void DeactivatePhone(){
		phone.interactable = false;
	}

	public void ActivatePhone(){
		phone.interactable = true;
	}

	public void UpdateCanvas(){
		int sanity = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ResourcesScript> ().getSanityLevel();
		// Prevent indexoverflow!!!
		for (int i = 0; i < sanity; i++) {
			items[i].SetActive(true);
		}
	}

	public void ActivateComputer(){
		computer.interactable = true;
	}

	public void DeactivateComputer(){
		computer.interactable = false;
	}
}
