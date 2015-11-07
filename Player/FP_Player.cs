using UnityEngine;
using System.Collections;

public class FP_Player : Player {

	void Awake () {
		maxDice = 4;
		rings = 3;
	}

	public override void Recruit(){

	}

	public override void AddDice(){
		Debug.Log("calling add dice for FP player. Count: " + diceCount);
	}

	public override void VictoryCheck(){
		diceCount = 0;
	}
}
