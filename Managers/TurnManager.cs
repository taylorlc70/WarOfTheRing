using UnityEngine;
using System.Collections;

public enum Turn{
	free,
	shadow
}

public class TurnManager : MonoBehaviour {

	public static Turn turn;

	void Awake(){
		turn = Turn.free;
	}

	public static void SwitchTurn(){
		if(turn == Turn.free){
			turn = Turn.shadow;
		} else {
			turn = Turn.free;
		}
	}
}
