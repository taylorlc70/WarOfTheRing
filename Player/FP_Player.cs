using UnityEngine;
using System.Collections;

public class FP_Player : Player {

	// Use this for initialization
	void Start () {
		maxDice = 4;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable(){
		GameManager.RecAndDraw += this.RecoverDice;
		GameManager.RecAndDraw += this.DrawCardsStart;
	}

	void OnDisable(){
		GameManager.RecAndDraw -= this.RecoverDice;
		GameManager.RecAndDraw -= this.DrawCardsStart;
	}
}
