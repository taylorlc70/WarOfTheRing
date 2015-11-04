using UnityEngine;
using System.Collections;

public class PoliMarker : MonoBehaviour {

	public bool active = false, atWar = false;
	public Nation nation;
	public int position;


	public void Advance(){
		if(active){
			position++;
		} else {
			Debug.Log("Cannot advance nation that is not at war");
		}
	}
	
	public void ActivateNation(){
		active = true;
	}

}
