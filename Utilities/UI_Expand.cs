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
			HideChildren(transform);
		}
		if(AppearOnEnable){
			StartCoroutine("_inflate");
		}
	}

	public void HideChildren(Transform trans){
		foreach(Transform child in trans){
			child.gameObject.SetActive(false);
			HideChildren(child);
		}
	}
	
	public void ShowChildren(Transform trans){
		foreach(Transform child in trans){
			child.gameObject.SetActive(true);
			ShowChildren(child);
		}
	}

	public void Inflate(){
		StartCoroutine("_inflate");
	}

	public void Deflate(){
		if(HideUntilFull){
			HideChildren(transform);
		}
		StartCoroutine("_deflate");
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
		ShowChildren(transform);
	}

	private IEnumerator _deflate(){
		Debug.Log("deflating...");
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
