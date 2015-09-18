using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveiScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		print ("starting movie");
		((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
