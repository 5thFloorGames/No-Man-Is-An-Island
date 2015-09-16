using UnityEngine;
using System.Collections;

public class Threat : ScriptableObject {

	private int radarValue;
	private int weaponValue;
	private bool enemy;
	private bool alive = true;

	public void setup(int radar, int weapon, bool enemy){
		radarValue = radar;
		weaponValue = weapon;
		this.enemy = enemy;
	}
	
	public override string ToString(){
		return ("Radar: " + radarValue + " Weapon value: " + weaponValue + " Enemy: " + enemy);
	}
}
