using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CanvasChanger : MonoBehaviour {

	//public Canvas canvas;
	public Dictionary<string, int> nameToIndex = new Dictionary<string, int>();
	public List<Canvas> canvases;
	public List<string> phone;
	public int phoneIndex = 0;
	public Canvas desk;
	public Threat threat;	
	
	// Use this for initialization
	void Start () {
		nameToIndex.Add("firstObs", 0);
		nameToIndex.Add("concl", 1);
		nameToIndex.Add("hayes", 2);
		nameToIndex.Add("wright", 3);
		phone.Add ("hayes");
		phone.Add ("wright");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Activate(string choice){
		if(choice.Equals("threat")){
			threat = ScriptableObject.CreateInstance<Threat> ();
			threat.setup (2, 1, false);
			print(threat.ToString ());
			desk.SendMessage("SetButtonsActive");
		} else if(choice.Equals("phone")){
			canvases [nameToIndex [phone[phoneIndex]]].GetComponent<ShutDownScript>().Toggle();
			phoneIndex++;
		} else if(choice.Equals("desk")){
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
