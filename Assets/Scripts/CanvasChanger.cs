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
	public string[] storyLine = {"Text01H.Welcome","Text02W.Welcome","nextVessel","nextVessel","Text03H.Rumours","nextVessel",
	                             "increaseSanity","Text04W.Giveme","Text05H.Storm","Text06N.Resources","nextVessel","increaseSanity",
	                             "Text07W.Honor","nextVessel","increaseSanity","Text08H.Fishing","nextVessel","increaseSanity",
	                             "Text09W.Weapons","nextVessel","increaseSanity","Text10H.Regret","nextVessel","Text11H.Died",
	                             "Text12W.Island","Text13N.Resources","nextVessel","increaseSanity","Text14H.Missing","nextVessel",
	                             "increaseSanity","Text15W.Hate","nextVessel","increaseSanity","Text16H.Dreams","nextVessel","Text17W.Police",
		"TextTired","Text19N.Question","nextVessel","nextVessel","nextVessel","nextVessel","nextVessel","nextVessel"};
	public int storyLineIndex = 0;

	// Use this for initialization
	void Start () {
		nameToIndex.Add("Text01H.Welcome", 0);
		nameToIndex.Add("Text02W.Welcome", 1);
		nameToIndex.Add("Text03H.Rumours", 2);
		nameToIndex.Add("Text04W.Giveme", 3);
		nameToIndex.Add ("threatHayes", 4);
		nameToIndex.Add ("threatWright", 5);
		nameToIndex.Add ("radarFailure", 6);
		nameToIndex.Add ("radarSuccess", 7);
		nameToIndex.Add ("destroyedCivilians", 8);
		nameToIndex.Add ("enemyThrough", 9);
		nameToIndex.Add ("coffee", 10);
		nameToIndex.Add ("observation", 11);
		nameToIndex.Add ("Text05H.Storm", 12);
		nameToIndex.Add ("Text06N.Resources", 13);
		nameToIndex.Add ("Text07W.Honor", 14);
		nameToIndex.Add ("weaponFailure", 15);
		nameToIndex.Add ("weaponSuccess", 16);

		NextUp ();
		//phoneQueue.Enqueue ("hayes");
		//phoneQueue.Enqueue ("wright");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Activate(string choice){
		Canvas activatableCanvas = null;
		if (choice.Equals ("nextUp")) {
			NextUp();
			Activate("desk");
		} else if(choice.Equals("threat")){
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

	public bool eventsInPhone(){
		return phoneQueue.Count != 0;
	}

	private void NextUp(){
		string action = storyLine [storyLineIndex];
		storyLineIndex++;
		if (action.Equals ("nextVessel")) {
			this.gameObject.SendMessage ("CreateThreat");
		} else if (action.Equals ("increaseSanity")) {
			this.SendMessage ("increaseSanity");
			NextUp();
		} else {
			addEventToPhone(action);		
		}
	}
}
