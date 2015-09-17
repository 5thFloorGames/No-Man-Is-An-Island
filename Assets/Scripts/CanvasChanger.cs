using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CanvasChanger : MonoBehaviour {

	//public Canvas canvas;
	public Dictionary<string, int> nameToIndex = new Dictionary<string, int>();
	public List<Canvas> canvases;
	public Canvas desk;
	private Queue<string> phoneQueue = new Queue<string>();

	// Use this for initialization
	void Start () {
		nameToIndex.Add("firstObs", 0);
		nameToIndex.Add("concl", 1);
		nameToIndex.Add("hayes", 2);
		nameToIndex.Add("wright", 3);
		nameToIndex.Add ("threatHayes", 4);
		nameToIndex.Add ("threatWright", 5);
		nameToIndex.Add ("radarFailure", 6);
		nameToIndex.Add ("radarSuccess", 7);
		nameToIndex.Add ("weaponFailure", 6);
		nameToIndex.Add ("weaponSuccess", 7);
		nameToIndex.Add ("destroyedCivilians", 8);
		nameToIndex.Add ("enemyThrough", 9);
		nameToIndex.Add ("coffee", 10);
		nameToIndex.Add ("observation", 11);

		this.gameObject.SendMessage("CreateThreat");
		//phoneQueue.Enqueue ("hayes");
		//phoneQueue.Enqueue ("wright");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Activate(string choice){
		Canvas activatableCanvas = null;
		if(choice.Equals("threat")){
			activatableCanvas = canvases [nameToIndex ["observation"]];
		} else if (choice.Equals ("react")){
			desk.SendMessage("SetButtonsActive");
			desk.SendMessage("UpdateCanvas");
		} else if(choice.Equals("phone")){
			activatableCanvas = canvases [nameToIndex [phoneQueue.Dequeue()]];
			if(phoneQueue.Count == 0){
				desk.SendMessage("DeactivatePhone");
			}

		} else if(choice.Equals("desk")){
			desk.SendMessage("TurnButtonsOn");
			desk.SendMessage("UpdateCanvas");
		} else {
			activatableCanvas = canvases [nameToIndex [choice]];
			desk.SendMessage("TurnButtonsOff");
		}
		if (activatableCanvas != null) {
			activatableCanvas.GetComponent<ShutDownScript> ().Toggle ();
			activatableCanvas.SendMessage ("UpdateCanvas");
		}
	}

	private void printKeys(){
		print(nameToIndex.Keys);
	}

	public void addEventToPhone(string eventName){
		phoneQueue.Enqueue(eventName);
		desk.SendMessage ("ActivatePhone");
		print ("event added");
	}
}
