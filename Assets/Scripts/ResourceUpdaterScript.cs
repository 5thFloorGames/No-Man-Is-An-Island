using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceUpdaterScript : MonoBehaviour {

	public GameObject logic;
	public Text radars;
	public Text weapons;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		weapons.text = "Weapon assets: " + logic.GetComponent<ResourcesScript>().getWeapons();
		radars.text = "Radar Energy: " + logic.GetComponent<ResourcesScript>().getRadars();	
	}
}
