using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcesScript : MonoBehaviour {

	private int radars = 16;
	private int weapons = 16;
	private int sanityLevel = 0;
	private Threat threat;
	public CanvasChanger CanvasChanger;
	string[] names = {"A small civilian passenger ship", "An enemy scout", "A friendly container vessel",
		"An enemy missile boat", "An enemy stealth scout", "An enemy class-5 corvette", "An enemy destroyer",
		"A threatening warship", "A civilian schooner filled with hope", "A sea serpent", "My father’s old wooden rowboat",
		"A chthonian hydra", "Something eldritch rising from the sea", "Forgiveness", "Shame, guilt and regret",
		"The bodies beneath the waves", "How it could have been avoided", "Me"};	
	int[] radarValues = {1,2,2,2,3,2,2,1,3,2,3,1,1,3,1,2,2,3};
	int[] weaponValues = {1,1,2,2,1,3,4,2,1,2,1,3,4,3,3,3,2,4};
	bool[] enemies = {false, true, false, true, true, true, true, true, false, true, false, true, true, false, true, true, true, true};
	int threatIndex = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateThreat(){
		threat = ScriptableObject.CreateInstance<Threat> ();
		threat.setup (radarValues[threatIndex], weaponValues[threatIndex], enemies[threatIndex], names[threatIndex], "tiny");
		threatIndex++;
		GameObject.FindGameObjectWithTag("Desk").SendMessage("ActivateComputer");
		print(threat.ToString ());
	}

	public void reactRadar(int amount){
		if (useRadars (amount)) {
			CanvasChanger.addEventToPhone ("radarSuccess");
		} else {
			CanvasChanger.addEventToPhone ("radarFailure");
		}
	}

	public bool useRadars(int amount){
		reduceRadars (amount);
		if (threat.getRadarValue() <= amount) {
			return true;
		} else {
			return false;
		}
	}

	public void reactWeapon(int amount){
		if (useWeapons (amount)) {
			threat.die();
			if(!threat.getEnemy()){
				//sanityLevel++;
				CanvasChanger.addEventToPhone ("destroyedCivilians");
			} else{
				CanvasChanger.addEventToPhone ("weaponSuccess");
			}
		} else {
			if(threat.getEnemy()){
				sanityLevel++;
				CanvasChanger.addEventToPhone ("enemyThrough");
			} else {
				CanvasChanger.addEventToPhone ("weaponFailure");
			}
		}	
	}
	
	public bool useWeapons(int amount){
		reduceWeapons (amount);
		if (threat.getWeaponValue() <= amount) {
			return true;
		} else {
			return false;
		}
	}
	
	public int getRadars(){
		return radars;
	}

	public int getWeapons(){
		return weapons;
	}

	public int getSanityLevel(){
		return sanityLevel;
	}

	public Threat getThreat(){
		return threat;
	}

	public void increaseSanityLevel(int amount){
		sanityLevel += amount;
	}

	public void increaseSanity(){
		sanityLevel++;
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
