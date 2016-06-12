using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class NPCController : MonoBehaviour {

	public Image IconContainer;
	public float scaleTweenTime = 1.0f;

	private Dictionary <string, Image> iconsDict = new Dictionary<string, Image>();

	// Use this for initialization
	void Awake () 
	{
		if (IconContainer == null)
			GameObject.FindGameObjectWithTag("NPCIconContainer").GetComponent<Image>();

		IconContainer.gameObject.SetActive(false);
		GameManager.CacheIcons(iconsDict, IconContainer);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}


	public void EnableIconContainer()
	{
		IconContainer.gameObject.SetActive(true);
		//IconContainer.transform.localScale = Vector3.zero;
		//LeanTween.moveX(IconContainer.gameObject, Vector3.one, scaleTweenTime).setEase(LeanTweenType.easeOutQuint);
		LeanTween.moveX(IconContainer.rectTransform, 0, 0.5f);
	}


}
