using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcesScript : MonoBehaviour {

	private int radars = 10;
	private int weapons = 10;
	private int sanityLevel = 0;
	private Threat threat;
	public CanvasChanger CanvasChanger;


	string[] names = {
		"a small civilian passenger ship carrying supplies", 
		"an enemy patrol vessel, used mainly for scouting", 
		"a friendly container vessel carrying munitions",
		"a light enemy missile boat",  
		"an enemy class-5 corvette, used to support and protect heavier vessels",
		"an octopus-like underwater enemy minesweeper",
		"an enemy destroyer equipped with shame, guilt and regret",
		"an enemy aircraft carrier equipped with several G50-fighters, and bombers carrying liquid hate", 
		"a civilian schooner filled with hope",
		"a mechanical, steam-operated hydra from the underworld", 
		"my father’s old oaken rowboat",
		"something eldritch rising from the bottom of the sea and washing the shores with blood of our ", 
		"forgiveness", 
	};	
	int[] radarValues = {1,2,2,2,3,2,2,3,2,3,1,1,3};
	int[] weaponValues = {1,1,2,2,3, 3, 4, 1, 2, 1, 3, 4, 2};
	bool[] enemies = {false, true, false, true, true, true, true, false, true, false, true, true, false};
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
		//print(threat.ToString ());
	}

	public void reactRadar(int amount){
		if (useRadars (amount)) {
			CanvasChanger.Activate ("radarSuccess");
		} else {
			CanvasChanger.Activate ("radarFailure");
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
				CanvasChanger.Activate ("destroyedCivilians");
			} else{
				CanvasChanger.Activate ("weaponSuccess");
			}
		} else {
			if(threat.getEnemy()){
				//sanityLevel++;
				CanvasChanger.Activate ("enemyThrough");
			} else {
				CanvasChanger.Activate ("weaponFailure");
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
		if (radars < 0) {
			radars = 0;
		}
	}

	public void reduceWeapons(int amount){
		weapons -= amount;
		if (weapons < 0) {
			weapons = 0;
		}
	}

	public void addRadars(int amount){
		radars += amount;
	}
	
	public void addWeapons(int amount){
		weapons += amount;
	}
}
