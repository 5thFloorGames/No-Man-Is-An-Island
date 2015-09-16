using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CanvasChanger : MonoBehaviour {

	//public Canvas canvas;
	public Dictionary<string, int> nameToIndex = new Dictionary<string, int>();
	public List<Canvas> canvases;
	public Canvas desk;

	// Use this for initialization
	void Start () {
		nameToIndex.Add("firstObs", 0);
		nameToIndex.Add("concl", 1);
		nameToIndex.Add ("welcome", 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Activate(string choice){
		if(choice.Equals("desk")){
			desk.SendMessage("TurnButtonsOn");
		} else {
			canvases [nameToIndex [choice]].GetComponent<ShutDownScript>().Toggle();
			desk.SendMessage("TurnButtonsOff");
		}
		//Instantiate (canvas);
		//canvas.SetActive = true;
		//Canvas canvasS = (Canvas)canvas;
	}

	private void printKeys(){
		print(nameToIndex.Keys);
	}
}
