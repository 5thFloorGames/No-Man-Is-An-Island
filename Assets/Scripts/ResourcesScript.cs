using UnityEngine;
using System.Collections;

public class ResourcesScript : MonoBehaviour {

	private int radars = 2;
	private int weapons = 2;
	private int sanityLevel = 0;
	private Threat threat;
	public CanvasChanger CanvasChanger;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateThreat(){
		threat = ScriptableObject.CreateInstance<Threat> ();
		threat.setup (2, 1, false, "rowboat", "tiny");
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
				sanityLevel++;
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
