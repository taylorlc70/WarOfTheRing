using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoliticalTrack : MonoBehaviour {

	public PoliMarker gondor;
	public PoliMarker rohan;
	public PoliMarker dwarves;
	public PoliMarker elves;
	public PoliMarker northmen;
	public PoliMarker isengard;
	public PoliMarker sauron;
	public PoliMarker east; 

	public List<PoliMarker> markers;

	void Awake(){
		gondor.position = 1;
		rohan.position = 0;
		dwarves.position = 0;
		elves.position = 0;
		northmen.position = 0;
		isengard.position = 2;
		sauron.position = 2;
		east.position = 1;
		gondor.nation = Nation.Gondor;
		rohan.nation = Nation.Rohan;
		dwarves.nation = Nation.Dwarves;
		elves.nation = Nation.Elves;
		northmen.nation = Nation.Northmen;
		isengard.nation = Nation.Isengard;
		sauron.nation = Nation.Sauron;
		east.nation = Nation.Easterlings;
		markers.Add(gondor);
		markers.Add(rohan);
		markers.Add(dwarves);
		markers.Add(elves);
		markers.Add (northmen);
		markers.Add (isengard);
		markers.Add(sauron);
		markers.Add(east);
		markers.ForEach(delegate(PoliMarker obj) {
			obj.active = false;
			obj.atWar = false;
		});
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
