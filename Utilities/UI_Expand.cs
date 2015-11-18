using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof (RectTransform))]
public class UI_Expand : MonoBehaviour {

	public float collapsedHeight;
	public float collapsedWidth;
	public float desiredWidth = 300.0f;
	public float desiredHeight = 190.0f;
	private float finalPanelAspect;
	public float speed = 300.0f;
	public bool HideUntilFull = false;
	public bool AppearOnEnable = true;
	private RectTransform myRect;
	
	void Start () {
		finalPanelAspect = desiredWidth/desiredHeight;
		myRect = gameObject.GetComponent<RectTransform>();
		collapsedWidth= myRect.sizeDelta.x;
		collapsedHeight = myRect.sizeDelta.y;
		if(HideUntilFull){
			//HideChildren(transform);
		}
		if(AppearOnEnable){
			StartCoroutine("_inflate");
		}
	}

	public void HideChildren(){
		Disappearable[] children = gameObject.GetComponentsInChildren<IDisappearableUI>();
		foreach(Disappearable child in children){
			child.Disappear();
		}
	}
	
	public void ShowChildren(){

	}

	public void StartDeflateTimer(){
		StartCoroutine("_deflateTimer");
	}

	public void StopDeflateTimer(){
		StopCoroutine("_deflateTimer");
	}

	public void Inflate(){
		StartCoroutine("_inflate");
	}

	public void Deflate(){
		StartCoroutine("_deflate");
	}

	private IEnumerator _deflateTimer(){
		yield return new WaitForSeconds(3);
		Deflate ();
	}

	private IEnumerator _inflate(){
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
		//ShowChildren(transform);
	}

	private IEnumerator _deflate(){
		if(HideUntilFull){
			//HideChildren(transform);
		}
		float wd = myRect.sizeDelta.x;
		float hd = myRect.sizeDelta.y;
		while(wd > collapsedWidth || hd > collapsedHeight){
			wd -= speed * finalPanelAspect * Time.deltaTime;
			hd -= speed * Time.deltaTime;
			if( wd < collapsedWidth){
				wd = collapsedWidth;
			}
			if(hd < collapsedHeight){
				hd = collapsedHeight;
			}
			myRect.sizeDelta = new Vector2(wd, hd);
			yield return null; 
		}
		myRect.sizeDelta = new Vector2(collapsedWidth, collapsedHeight);
	}
}
