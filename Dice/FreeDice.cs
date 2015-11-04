using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FreeDice : Dice {

	Player player;

	// Order: CHAR, EV, muster, musterArmy, WW, Char
	void Start (){
		player = GameObject.FindObjectOfType<FP_Player>();
		myImg = gameObject.GetComponent<Image>();
		modalPrefab = Resources.Load("Prefabs/FreeModal") as GameObject;
	}	

	public override void SetButtons(int index){
		buttons.Clear();
		Debug.Log ("Free setbuttons");
		switch(index){
		case 0: //char
			CharButtons();
			break;
		case 1: //event
			EventButtons();
			break;
		case 2: //muster
			MusterButtons();
			break;
		case 3: //musterArmy
			MusterButtons();
			ArmyButtons();
			break;
		case 4: //ww
			WillWest();
			break;
		case 5: //char
			CharButtons();
			break;
		}
	}

	//TODO: Only add buttons according to which actions are available (disable the unavailable ones)
	private void CharButtons(){
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_LeaderMA") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_CharEventCard") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_SeperateCompanion") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_MoveCompanions") as GameObject);
	}

	private void EventButtons(){
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_DrawEventCard") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_PlayEventCard") as GameObject);
	}

	private void MusterButtons(){
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_Political") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_Recruit") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_MusterEventCard") as GameObject);
	}

	private void ArmyButtons(){
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_MoveArmies") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_Attack") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_ArmyEventCard") as GameObject);
	}

	private void WillWest(){
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_ChangeDice") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_GandalfWhite") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_Aragorn") as GameObject);
	}
}
