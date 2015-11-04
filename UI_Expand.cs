using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof (RectTransform))]
public class UI_Expand : MonoBehaviour {

	public float desiredWidth = 300.0f;
	public float desiredHeight = 190.0f;
	private float finalPanelAspect;
	public float speed = 300.0f;
	private RectTransform myRect;

	void Start () {
		finalPanelAspect = desiredWidth/desiredHeight;
		myRect = gameObject.GetComponent<RectTransform>();
		StartCoroutine("Appear");
	}

	private IEnumerator Appear(){
		float wd = myRect.sizeDelta.x;
		float hd = myRect.sizeDelta.y;
		while(desiredHeight > hd || desiredWidth > wd){
			wd += speed * finalPanelAspect * Time.deltaTime;
			hd += speed * Time.deltaTime;
			if( wd > desiredWidth){
				wd = desiredWidth;
			}
			if(hd > desiredHeight){
				hd = desiredHeight;
			}
			myRect.sizeDelta = new Vector2(wd, hd);
			yield return null; 
		}
		myRect.sizeDelta = new Vector2(desiredWidth, desiredHeight);
	}
}
