using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class NPCController : MonoBehaviour {

	public Image IconContainer;

	private Dictionary <string, Image> iconsDict = new Dictionary<string, Image>();

	// Use this for initialization
	void Awake () 
	{
		if (IconContainer == null)
		{
			Debug.LogError("Icon container is not defined.Did you hook it up in the editor?");
		}

		foreach(Transform icon in IconContainer.transform)
		{
			var imageIcon = icon.GetComponent<Image>();
			iconsDict.Add(icon.gameObject.tag, imageIcon);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
