using UnityEngine;
using System.Collections;

public class ShutDownScript : MonoBehaviour {

	public bool isOn = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Toggle () {
		isOn = !isOn;
		this.gameObject.SetActive (isOn);
	}
}
