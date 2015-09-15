using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CanvasChanger : MonoBehaviour {

	//public Canvas canvas;
	public Dictionary<string, int> nameToIndex = new Dictionary<string, int>();
	public List<Canvas> canvases;

	// Use this for initialization
	void Start () {
		nameToIndex.Add("firstObs", 0);
		nameToIndex.Add("concl", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Activate(string choice){
		canvases [nameToIndex [choice]].GetComponent<ShutDownScript>().Toggle();
		//Instantiate (canvas);
		//canvas.SetActive = true;
		//Canvas canvasS = (Canvas)canvas;
	}

	private void printKeys(){
		print(nameToIndex.Keys);
	}
}
