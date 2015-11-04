using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShadowDice : Dice {

	Player player;

	// Order: CHAR, EV, muster, musterArmy, eye, army
	void Start (){
		player = GameObject.FindObjectOfType<SH_Player>();
		myImg = gameObject.GetComponent<Image>();
		modalPrefab = Resources.Load("Prefabs/ShadowModal") as GameObject;
	}

	public override void SetButtons(int index){
		buttons.Clear();
		Debug.Log ("Shadow setbuttons");
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
		case 4: //eye
			Eye();
			break;
		case 5: //army
			ArmyButtons();
			break;
		}
	}

	//TODO: Only add buttons according to which actions are available (disable the unavailable ones)
	private void CharButtons(){
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_LeaderMA") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_CharEventCard") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_MoveMinions") as GameObject);
	}

	private void EventButtons(){
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_DrawEventCard") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_PlayEventCard") as GameObject);
	}

	private void MusterButtons(){
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_Political") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_Recruit") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_MusterEventCard") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_SummonMinion") as GameObject);
	}

	private void ArmyButtons(){
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_MoveArmies") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_Attack") as GameObject);
		buttons.Add(Resources.Load("Prefabs/ActionButtons/BN_ArmyEventCard") as GameObject);
	}

	private void Eye(){
		StartCoroutine("eyeCoroutine");
	}

	IEnumerator eyeCoroutine(){
		Debug.Log("Eye coroutine");
		yield return null;
	}
}
