using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Modal : MonoBehaviour {
	
	void Awake(){
		UI_Modal[] others = GameObject.FindObjectsOfType<UI_Modal>();
		if(others.Length > 0){
			foreach(UI_Modal other in others){
				if(other != this){
					Destroy(other.gameObject);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Dispose(){
		Destroy (gameObject);
	}

}
