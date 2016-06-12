using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class NPCController : MonoBehaviour {

	public RectTransform NPCThoughtPanel;

	public Image IconContainer;
	public float scaleTweenTime = 1.0f;

	public Vector3 initialPosition = Vector3.zero;

	private Dictionary <string, Image> iconsDict = new Dictionary<string, Image>();

	// Use this for initialization
	void Awake () 
	{
		if (IconContainer == null)
			GameObject.FindGameObjectWithTag("NPCIconContainer").GetComponent<Image>();

//		IconContainer.gameObject.SetActive(false);
		GameManager.CacheIcons(iconsDict, IconContainer);

		initialPosition = IconContainer.transform.position;

		EnableThoughtPanel(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}


//	public void EnableIconContainer(bool enable)
//	{
//		if (enable)
//		{
//			IconContainer.gameObject.SetActive(true);
//			//IconContainer.transform.localScale = Vector3.zero;
//			//LeanTween.moveX(IconContainer.gameObject, Vector3.one, scaleTweenTime).setEase(LeanTweenType.easeOutQuint);
//			LeanTween.moveX(IconContainer.rectTransform, 0, 0.5f);
//		}
//		else
//		{
//			
//			//IconContainer.transform.localScale = Vector3.zero;
//			//LeanTween.moveX(IconContainer.gameObject, Vector3.one, scaleTweenTime).setEase(LeanTweenType.easeOutQuint);
//			LeanTween.moveX(IconContainer.rectTransform, initialPosition.x, 0.5f).setOnComplete(() =>
//			{
//				IconContainer.gameObject.SetActive(false);
//			 	//LeanTween.moveX(IconContainer.rectTransform, initialPosition.x, 0.5f);
//
//			});
//		}
//	}

	public void EnableThoughtPanel(bool enable)
	{
//		if (enable)
//		{
//			LeanTween.scale(NPCThoughtPanel, Vector3.one, 0.5f);
//		}
//		else
//		{
//			LeanTween.scale(NPCThoughtPanel, Vector3.zero, 0.5f);
//		}
	}

	public void SetIcon()
	{
		
	}


}
