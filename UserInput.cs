using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class UserInput : MonoBehaviour {
	private static UserInput instance;
	public static UserInput Instance {
		get{
			if (instance == null) {
				instance = GameObject.FindObjectOfType<UserInput>();
				DontDestroyOnLoad(instance.gameObject);
			} 
			return instance;
		}
	}

	public static Dice chosenDice;
	private List<Army> chosenArmies;
	
	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			if(this != instance){
				Destroy(instance);
			}
		}
	}

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
