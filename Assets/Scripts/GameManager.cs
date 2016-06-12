using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	//---------------------------------------------------------------------------------------------------------------------------
	// Public Variables
	//---------------------------------------------------------------------------------------------------------------------------

	//public PlayerController player;
	public static GameManager Instance;
	public static float v, h;


	//---------------------------------------------------------------------------------------------------------------------------
	// Private Variables
	//---------------------------------------------------------------------------------------------------------------------------

	// Use this for initialization
	void Awake () 
	{
		if(Instance == null)
			Instance = this;
		else 
			Destroy(this);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//inputDevice = InputManager.ActiveDevice;
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
	}

	public static void CacheIcons(Dictionary<string, Image> iconsDict, Image container)
	{	

		if (container == null)
		{
			container = GameObject.FindGameObjectWithTag("NPCIconContainer").GetComponent<Image>();

			//Debug.LogError("Icon container is not defined.Did you hook it up in the editor?");
		}

		var containerTransf = container.transform;

		foreach(Transform icon in containerTransf)
		{
			var imageIcon = icon.GetComponent<Image>();
			iconsDict.Add(icon.gameObject.tag, imageIcon);
		}
	}
}
