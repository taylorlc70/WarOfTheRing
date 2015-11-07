using UnityEngine;
using System.Collections;

public class Army : MonoBehaviour {

	public bool marching;
	public GameObject location;
	private int speed = 10;
	public GameObject dest;
	public bool selected = false;
	public Side side;

	// Use this for initialization
	void Start () {
		//Subscribe to click event
		//UserInput.ObjectClick += this.March;
	}

	void Update(){
		if(marching){
			transform.position = Vector3.MoveTowards(transform.position, dest.transform.position, speed * Time.deltaTime);
			if(transform.position == dest.transform.position){
				marching = false;
				location = dest;
			}
		}
	}

	public void March(GameObject _dest){
		marching = true;
		dest = _dest;
		//Want to eventually replace the update march with a coroutine
	}

	void OnDisable(){
		//UserInput.ObjectClick -= March;
	}
}
