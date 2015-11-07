using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Player : MonoBehaviour {
	
	public List<GameObject> myDice;
	public List<iCard> hand;
	public List<Army> myArmies;
	public int maxDice;
	public int handCount = 0;
	public int rings;
	public const int MAX_HAND_SIZE = 6;

	public int diceCount = 0;

	public abstract void Recruit();
	public abstract void AddDice();
	public abstract void VictoryCheck();
	
	public void DrawCardsStart(){
		Debug.Log(gameObject.name + " is drawing cards");
	}

	public void DrawCard(int num, iCard type){
		while(num-- > 0 && handCount < MAX_HAND_SIZE){
			handCount++;
		}
	}
	
	public void RecoverDice(){
		Debug.Log(gameObject.name + " is recovering dice");
		int counter = maxDice;
		while(counter-- > 0){
			diceCount++;
			AddDice ();
		}
	}

	public void MoveOrAttack(){
		UserInput.Instance.InitiateArmyMovement(myArmies);
	}
	
	void OnEnable(){
		GameManager.RecAndDraw += this.RecoverDice;
		GameManager.RecAndDraw += this.DrawCardsStart;
		GameManager.VictoryCheck += this.VictoryCheck;
	}
	
	void OnDisable(){
		GameManager.RecAndDraw -= this.RecoverDice;
		GameManager.RecAndDraw -= this.DrawCardsStart;
		GameManager.VictoryCheck -= this.VictoryCheck;
	}
}
