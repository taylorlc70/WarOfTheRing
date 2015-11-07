using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class UserInput : MonoBehaviour {

	public static Dice chosenDice;
	private List<Army> chosenArmies;

	public void InitiateArmyMovement(List<Army> armies){
		chosenArmies = armies;
		foreach(Army army in armies){
			army.location.GetComponent<BoardSpace>().Highlight();
		}
	}

	public void CancelArmyMovement(){
		//TODO: move any moved armies back to their starting location
		foreach(Army army in chosenArmies){
			army.location.GetComponent<BoardSpace>().Highlight();
		}
		chosenArmies = null;
	}
}
