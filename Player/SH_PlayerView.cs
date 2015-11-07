using UnityEngine;
using System.Collections;
/*
This class acts as the view for the SH human player
 */
public class SH_PlayerView : SH_Player {
	public string dicePrefabPath;

	void Start(){
		dicePrefabPath = "Prefabs/ShDice";
	}
	public override void AddDice(){
		base.AddDice();
		Debug.Log("calling add dice for FP player");
		GameObject newDice = Instantiate (Resources.Load(dicePrefabPath), new Vector2(0,0), Quaternion.Euler (Vector3.zero)) as GameObject;
		newDice.transform.SetParent(transform, false);
	}
}
