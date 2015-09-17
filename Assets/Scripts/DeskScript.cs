using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DeskScript : MonoBehaviour {

	public List<Button> buttons;
	public List<Button> activatableOnThreat;
	public Button phone;
	public Button computer;

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

	}

	public void ActivateComputer(){
		computer.interactable = true;
	}

	public void DeactivateComputer(){
		computer.interactable = false;
	}
}
