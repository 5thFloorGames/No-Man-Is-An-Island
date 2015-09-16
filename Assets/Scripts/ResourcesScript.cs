using UnityEngine;
using System.Collections;

public class ResourcesScript : MonoBehaviour {

	private int radars = 5;
	private int weapons = 5;
	private int sanityLevel = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getRadars(){
		return radars;
	}

	public int getWeapons(){
		return weapons;
	}

	public void reduceRadars(int amount){
		radars -= amount;
	}

	public void reduceWeapons(int amount){
		weapons -= amount;
	}

	public void addRadars(int amount){
		radars += amount;
	}
	
	public void addWeapons(int amount){
		weapons += amount;
	}
}
