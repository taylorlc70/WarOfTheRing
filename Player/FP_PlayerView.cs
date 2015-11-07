using UnityEngine;
using System.Collections;
/*
This class acts as the view for the FP human player
 */
public class FP_PlayerView : FP_Player {
	public string dicePrefabPath;

	void Start(){
		dicePrefabPath = "Prefabs/FpDice";
	}
	public override void AddDice(){
		base.AddDice();
		Debug.Log("calling add dice for FP player view. Count: " + diceCount);
		GameObject newDice = Instantiate (Resources.Load(dicePrefabPath), new Vector2(0,0), Quaternion.Euler (Vector3.zero)) as GameObject;
		newDice.transform.SetParent(transform, false);
	}
}
