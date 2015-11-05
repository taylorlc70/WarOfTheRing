using UnityEngine;
using System.Collections;

public enum Turn{
	free,
	shadow,
	none
}

public class TurnManager : MonoBehaviour {
	
	public delegate void TurnSwitchEvent();
	public static event TurnSwitchEvent FreeTurn;
	public static event TurnSwitchEvent ShadowTurn;
	public static Turn turn;

	void OnEnable(){
		GameManager.RecAndDraw += SetTurnToNone;
		GameManager.Fellowship += SetTurnToFree;
		GameManager.Hunt += SetTurnToShadow;
		GameManager.Action += SetTurnToFree;
		GameManager.VictoryCheck += SetTurnToNone;
	}

	void OnDisable(){
		GameManager.RecAndDraw -= SetTurnToNone;
		GameManager.Fellowship -= SetTurnToFree;
		GameManager.Hunt -= SetTurnToShadow;
		GameManager.Action -= SetTurnToFree;
		GameManager.VictoryCheck -= SetTurnToNone;
	}

	public void SwitchTurn(){
		if(turn == Turn.free){
			this.SetTurnToShadow();
		} else {
			this.SetTurnToFree();
		}
	}

	void SetTurnToFree(){
		turn = Turn.free;
		if(FreeTurn != null){
			FreeTurn();
		}
	}

	void SetTurnToShadow(){
		turn = Turn.shadow;
		if(ShadowTurn != null){
			ShadowTurn();
		}
	}

	void SetTurnToNone(){
		turn = Turn.none;
	}
}
