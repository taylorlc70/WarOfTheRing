using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
	public enum Location{
		Deck,
		Table,
		Hand,
		Discard
	}
	
	public Location location;
	public string mainName;
	public string mainAction;
	public string combatName;
	public string combatAction;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
