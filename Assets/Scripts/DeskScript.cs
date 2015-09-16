﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DeskScript : MonoBehaviour {

	public List<Button> buttons;

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

}