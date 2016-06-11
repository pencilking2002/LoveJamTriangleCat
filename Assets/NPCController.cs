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
		IconContainer.transform.localScale = Vector3.zero;
		LeanTween.scale(IconContainer.gameObject, Vector3.one, scaleTweenTime).setEase(LeanTweenType.easeOutQuint);
	}


}
