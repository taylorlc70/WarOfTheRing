using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
	The DiceView class is for Human players - it's the actual "view" on screen
 */
public class DiceView : Dice {

	public void SetInteractableTrue(){
		Debug.Log("Setting interactable to true");
		myButton.onClick.AddListener(this.SpawnMenu);
	}
	
	public void SetInteractableFalse(){
		myButton.onClick.RemoveListener(this.SpawnMenu);
	}
	
	public void SpawnMenu(){
		Debug.Log ("Calling spawn menu");
		//Spawn the menu
		myModal = (Instantiate(modalPrefab, new Vector2(0,0), Quaternion.Euler(Vector3.zero)) as GameObject);
		myModal.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
		myModal.transform.Find("CloseButton").GetComponent<Button>().onClick.AddListener(this.CloseMenu);
		buttons.ForEach(delegate(GameObject btn){
			GameObject bptr = Instantiate(btn, new Vector2(0,0), Quaternion.Euler(Vector3.zero)) as GameObject;
			bptr.transform.SetParent(myModal.transform, false);
			bptr.transform.SetAsFirstSibling();
		});
	}
	
	public void CloseMenu(){
		myModal.transform.Find("CloseButton").GetComponent<Button>().onClick.RemoveListener(this.CloseMenu);
		//Close the menu
		Destroy(myModal);
	}

	public override void Roll(){
		Debug.Log("DiceView rolling...");
		StartCoroutine("cRoll");
	}

	IEnumerator cRoll(){
		rolling = true;
		float waitTime = 0.01f;
		int index = 0;
		int last = -1;
		while(rolling){
			index = Random.Range(1,6);
			if(index != last){
				last = index;
				myImg.sprite = imgs[index];
				waitTime *= Random.Range(1.1f, 1.35f);
				if(waitTime > 0.8f){
					rolling = false;
					SetAvailableActions(index);
				}
				yield return new WaitForSeconds(waitTime);
			}
		}
	}
}
