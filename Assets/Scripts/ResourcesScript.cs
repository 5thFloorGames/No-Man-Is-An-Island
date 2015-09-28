using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcesScript : MonoBehaviour {

	private int radars = 16;
	private int weapons = 16;
	private int sanityLevel = 0;
	private Threat threat;
	public CanvasChanger CanvasChanger;
	string[] names = {"a small civilian passenger ship", "an enemy scout", "a friendly container vessel",
		"an enemy missile boat", "an enemy stealth scout", "an enemy class-5 corvette", "an enemy destroyer",
		"a threatening warship", "a civilian schooner filled with hope", "a sea serpent", "my father’s old wooden rowboat",
		"a chthonian hydra", "something eldritch rising from the sea", "forgiveness", "shame, guilt and regret",
		"the bodies beneath the waves", "how it could have been avoided", "me"};	
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
