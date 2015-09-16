using UnityEngine;
using System.Collections;

public class ResourcesScript : MonoBehaviour {

	private int radars = 5;
	private int weapons = 5;
	private int sanityLevel = 0;
	private Threat threat;	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateThreat(){
		threat = ScriptableObject.CreateInstance<Threat> ();
		threat.setup (2, 1, false);
		print(threat.ToString ());
	}

	public void reactRadar(int amount){
		print(useRadars (amount));
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
		print(useWeapons (amount));
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
