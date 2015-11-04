using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorldPopup : MonoBehaviour {

	private Button closeButton;

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
	// Use this for initialization
	void Start () {
		closeButton = transform.Find ("CloseButton").GetComponent<Button>();
		closeButton.onClick.AddListener(this.Dispose);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Dispose(){
		Destroy (gameObject);
	}
}
