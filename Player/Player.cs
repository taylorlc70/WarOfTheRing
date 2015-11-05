using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public List<GameObject> myDice;
	public List<iCard> hand;
	public List<Army> myArmies;
	public int maxDice;
	public int handCount = 0;
	public int rings;
	public string dicePrefabPath;
	public const int MAX_HAND_SIZE = 6;

	int diceCount = 0;
	//float panelLeft = 10.0f;
	//float panelTop = 10.0f;
	//float diceWidth = 58.0f;

	public void DrawCardsStart(){
		Debug.Log(gameObject.name + " is drawing cards");
	}

	public void DrawCard(int num, iCard type){
		while(num-- > 0 && handCount < MAX_HAND_SIZE){
			handCount++;
		}
		//TODO: deck management. Lists/arrays of cards on game manager? or its own object
		//Deck.pop
		//iCard newCard = Instantiate(/*CARD FROM DECK*/, transform.position, Quaternion.Euler(Vector3.zero)) as GameObject;
		//                   ^-- no, have the card script instantiate the object.
	}
	
	public void RecoverDice(){
		Debug.Log(gameObject.name + " is recovering dice");
		while(maxDice-- > 0){
			diceCount++;
			GameObject newDice = Instantiate (Resources.Load(dicePrefabPath), new Vector2(0,0), Quaternion.Euler (Vector3.zero)) as GameObject;
			newDice.transform.SetParent(transform, false);
		}
	}

	public void Recruit(){
		//if no existing army, make one and add to myArmies
		//if exisiting, add unit to it
	}

	public void MoveOrAttack(){
		UserInput.Instance.InitiateArmyMovement(myArmies);
	}

	public void CancelAction(){

	}

	public void RollDice(){

	}
}
