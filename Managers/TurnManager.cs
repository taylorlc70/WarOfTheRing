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
	public static event TurnSwitchEvent FreeAction;
	public static event TurnSwitchEvent ShadowAction;
	public static Turn turn = Turn.none;
	public static Turn actionTurn = Turn.none;

	void OnEnable(){
		GameManager.RecAndDraw += SetTurnsToNone;
		GameManager.Fellowship += SetTurnToFree;
		GameManager.Hunt += SetTurnToShadow;
		GameManager.Action += SetTurnToFree;
		GameManager.Action += SetActionToFree;
		GameManager.VictoryCheck += SetTurnsToNone;
	}

	void OnDisable(){
		GameManager.RecAndDraw -= SetTurnsToNone;
		GameManager.Fellowship -= SetTurnToFree;
		GameManager.Hunt -= SetTurnToShadow;
		GameManager.Action -= SetTurnToFree;
		GameManager.Action -= SetActionToFree;
		GameManager.VictoryCheck -= SetTurnsToNone;
	}

	public void SwitchTurn(){
		if(turn == Turn.free){
			this.SetTurnToShadow();
		} else {
			this.SetTurnToFree();
		}
	}

	public void SwitchAction(){
		if(actionTurn == Turn.free){
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

	void SetTurnsToNone(){
		turn = Turn.none;
		actionTurn = Turn.none;
	}

	void SetActionToFree(){
		actionTurn = Turn.free;
		if(FreeAction != null){
			FreeAction();
		}
	}

	void SetActionToShadow(){
		actionTurn = Turn.shadow;
		if(ShadowAction != null){
			ShadowAction();
		}
	}
	
}
