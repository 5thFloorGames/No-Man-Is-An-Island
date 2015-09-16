using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DeskScript : MonoBehaviour {

	public List<Button> buttons;
	public List<GameObject> activatableOnThreat;
	public Button phone;

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
		foreach(GameObject g in activatableOnThreat){
			g.SetActive(false);
		}
	}

	public void SetButtonsActive(){
		foreach(GameObject g in activatableOnThreat){
			g.SetActive(true);
		}
	}

	public void DeactivatePhone(){
		phone.interactable = false;
	}

	public void ActivatePhone(){
		phone.interactable = true;
	}

	public void UpdateCanvas(){

	}

}
