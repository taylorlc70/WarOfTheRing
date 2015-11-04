using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dice : MonoBehaviour, IDice {

	//Set in the INSPECTOR
	public List<Sprite> imgs;

	//Set in this script
	public bool interactable = false;
	public List<GameObject> buttons;
	public bool used;
	public GameObject myModal;
	public GameObject modalPrefab;
	public Image myImg;


	void Awake(){
		used = false;
	}
	// Use this for initialization
	void Start () {
		myImg = gameObject.GetComponent<Image>();
		modalPrefab = Resources.Load("Prefabs/UiPopup") as GameObject;
	}

	public void SpawnMenu(){
		if(interactable){
			UserInput.chosenDice = this;
			Debug.Log(gameObject.name + " was chosen");
			Debug.Log (buttons.Count);

			//Destroy existing modals
			GameObject[] modals = GameObject.FindGameObjectsWithTag("modal");
			if(modals.Length > 0){
				foreach(GameObject modal in modals){
					Destroy (modal);
				}
			}
			//Spawn the menu
			myModal = (Instantiate(modalPrefab, new Vector2(0,0), Quaternion.Euler(Vector3.zero)) as GameObject);
			myModal.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
			//myModal.transform.Find("CloseButton").GetComponent<Button>().onClick.AddListener(this.CloseMenu);
			buttons.ForEach(delegate(GameObject btn){
				GameObject bptr = Instantiate(btn, new Vector2(0,0), Quaternion.Euler(Vector3.zero)) as GameObject;
				bptr.transform.SetParent(myModal.transform, false);
			});
		}
	}

	public void CloseMenu(){
		UserInput.chosenDice = null;
		Debug.Log(gameObject.name + " is deactivated");
		//Close the menu
		Destroy(myModal);
	}

	public void Roll(){
		Debug.Log("rolling...");
		StartCoroutine("cRoll");
	}

	public virtual void SetButtons(int index){
		Debug.Log ("Dice setbuttons");
	}

	IEnumerator cRoll(){
		interactable = false;
		float waitTime = 0.01f;
		int index = 0;
		int last = -1;
		while(interactable == false){
			index = Random.Range(1,6);
			if(index != last){
				last = index;
				myImg.sprite = imgs[index];
				waitTime *= 1.3f;
				if(waitTime > 0.8f){
					interactable = true;
					SetButtons(index);
				}
				yield return new WaitForSeconds(waitTime);
			}
		}
	}
}
