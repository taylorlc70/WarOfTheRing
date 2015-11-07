using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PhaseText : MonoBehaviour {

	private Text text;

	void Awake(){
		text = gameObject.GetComponent<Text>();
	}
	void OnEnable(){
		GameManager.GamePhaseSwitched += setText;
	}
	
	void OnDisable(){
		GameManager.GamePhaseSwitched -= setText;
	}

	void setText(){
		Debug.Log("setting text");
		text.text = "Phase: " + GameManager.currentPhase;
	}
}
