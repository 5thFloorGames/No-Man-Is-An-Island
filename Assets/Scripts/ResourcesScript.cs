using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcesScript : MonoBehaviour {

	private int radars = 10;
	private int weapons = 10;
	private int sanityLevel = 0;
	private Threat threat;
	public CanvasChanger CanvasChanger;


	// Use this for initialization
	void Start () {
		AddVessel ("a small civilian container ship carrying supplies", 1, 2, false);
		AddVessel ("an enemy patrol vessel, used mainly for scouting", 2, 2, true);
		AddVessel ("a friendly passenger ship carrying refugees", 2, 1, false);
		AddVessel ("a light enemy missile boat", 1, 1, true);
		AddVessel ("an enemy class-5 corvette, used to support and protect heavier vessels", 2, 3, true);
		AddVessel ("an octopus-like underwater enemy minesweeper", 3, 3, true);
		AddVessel ("an enemy destroyer equipped with shame, guilt and regret", 3, 3, true);
		AddVessel ("an enemy aircraft carrier with a dozen of G50-bombers carrying liquid hate", 3, 4, true);
		AddVessel ("a civilian schooner filled with hope", 2, 2, false);
		AddVessel ("a mechanical, steam-operated hydra from the underworld", 3, 2, true);
		AddVessel ("an old oaken rowboat, both oars still aboard", 1, 2, false);
		AddVessel ("something eldritch rising from the bottom of the sea, its foam washing the shores with blood", 3, 4, true);
		AddVessel ("a reflection of a moon on a calm lake during the last days of indian summer, just before the storm", 3, 3, false);
	
		threatIndex = 0;
	}


	string[] names = new string[13];	
	int[] radarValues = new int [13];
	int[] weaponValues = new int [13];
	bool[] enemies = new bool[13];
	int threatIndex = 0;


	
	// Update is called once per frame
	void Update () {
	
	}

	private void AddVessel (string name, int radarValue, int weaponValue, bool enemy){
		names[threatIndex] = name;
		radarValues[threatIndex] = radarValue;
		weaponValues[threatIndex] = weaponValue;
		enemies [threatIndex] = enemy;
		threatIndex++;
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
