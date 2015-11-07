using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dice : MonoBehaviour, IDice {

	//Set in the INSPECTOR
	public List<Sprite> imgs;

	//Set in this script
	public bool rolling = false;
	public List<GameObject> buttons;
	public bool used;
	public GameObject myModal;
	public GameObject modalPrefab;
	public Image myImg;
	public Button myButton;


	void Awake(){
		used = false;
		myButton = gameObject.GetComponent<Button>();
	}
	// Use this for initialization
	void Start () {
		myImg = gameObject.GetComponent<Image>();
		modalPrefab = Resources.Load("Prefabs/UiPopup") as GameObject;
	}

	public void SelectDie(){
		UserInput.chosenDice = this;
	}

	public void DeselectDie(){
		UserInput.chosenDice = null;
	}

	public void Dispose(){
		UserInput.chosenDice = null;
		Destroy (gameObject);
	}

	public virtual void Roll(){
		Debug.Log("DICE PARENT rolling...");
	}

	public virtual void SetAvailableActions(int index){
		Debug.Log ("Dice SetAvailableActions");
	}


}
