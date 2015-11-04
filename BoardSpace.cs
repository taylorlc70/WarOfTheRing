using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;


public class BoardSpace : MonoBehaviour, IInfoPanel {

	public List<string> adjacentSpaces;
	public Side side;

	delegate void ClickActionDel();
	private ClickActionDel clickAction;


	private GameObject popup;

	void Start(){
		adjacentSpaces = GameManager.GetAdjacentSpaces(gameObject.name);
		clickAction += BringUpInfo;
		popup = Resources.Load("Prefabs/WorldPopup") as GameObject;
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject()){
			this.Highlight();
			if(clickAction != null){
				clickAction();
			}
		}
	}
	void OnMouseExit(){
		//Debug.Log("Mouse leaving " + gameObject.name);
	}

	public void BringUpInfo(){
		Debug.Log("Showing info for " + gameObject.name);
		popup = (Instantiate(popup, transform.position, Quaternion.Euler(Vector3.zero)) as GameObject);
	}

	public void Highlight(){
		Debug.Log(gameObject.name + " is highlighted");
	}

	public void Unhighlight(){

	}

	void OnEnable(){
	}

	void OnDisable(){

	}

}
