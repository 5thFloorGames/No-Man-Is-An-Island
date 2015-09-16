using UnityEngine;
using System.Collections;

public class Threat : ScriptableObject {

	private int radarValue;
	private int weaponValue;
	private bool enemy;
	private bool alive = true;
	private string threatName;

	public void setup(int radar, int weapon, bool enemy, string name){
		radarValue = radar;
		weaponValue = weapon;
		this.enemy = enemy;
		threatName = name;
	}
	
	public override string ToString(){
		return ("Radar: " + radarValue + " Weapon value: " + weaponValue + " Enemy: " + enemy);
	}

	public int getRadarValue(){
		return radarValue;
	}

	public int getWeaponValue(){
		return weaponValue;
	}

	public string getName(){
		return threatName;
	}

	public void die(){
		alive = false;
	}
}
