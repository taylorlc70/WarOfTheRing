using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorldPopup : MonoBehaviour {
	
	void Awake(){
		WorldPopup[] others = GameObject.FindObjectsOfType<WorldPopup>();
		if(others.Length > 0){
			foreach(WorldPopup other in others){
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
