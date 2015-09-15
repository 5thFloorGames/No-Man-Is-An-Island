using UnityEngine;
using System.Collections;

public class CanvasChanger : MonoBehaviour {

	public Canvas canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Activate(){
		Instantiate (canvas);
		//canvas.SetActive = true;
		//Canvas canvasS = (Canvas)canvas;
	}
}
