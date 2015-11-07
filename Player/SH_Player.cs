using UnityEngine;
using System.Collections;

public class SH_Player : Player {

	void Awake () {
		maxDice = 7;
		rings = 0;
	}

	public override void Recruit(){

	}

	public override void AddDice(){
		Debug.Log("calling add dice for SH player. Count: " + diceCount);
	}

	public override void VictoryCheck(){
		diceCount = 0;
	}
}
