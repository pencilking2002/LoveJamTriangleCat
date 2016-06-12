using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class IconsInit : MonoBehaviour {

	//public RectTransform icon1, icon2, icon3, icon4;

	public static IconsInit Instance;

	public IconChoice Icon1;
	public IconChoice Icon2;
	public IconChoice Icon3;
	public IconChoice Icon4;

	private IconChoice[] iconChoiceArr = new IconChoice[4];

	private List<string> iconChoicesNames = new List<string>()
	{
		"Heart",
		"Star",
		"Sun",
		"Cat"
	};

	//public Dictionary<RectTransform, Sprite> IconChoice = Dicticonary<RectTransform, Sprite>();
	//public Dictionary<IconChoice, Dictionary<RectTransform, Sprite>>iconsDict = new Dictionary<IconChoice, Dictionary<RectTransform, Sprite>>();

//	public enum IconChoice
//	{
//		Star,
//		Cat,
//		Heart,
//		Sun
//	} 

	// Use this for initialization
	void Awake () 
	{
		if (Instance == null)
			Instance = this;
		else
			Instance = this;

		iconChoiceArr[0] = Icon1;
		iconChoiceArr[1] = Icon2;
		iconChoiceArr[2] = Icon3;
		iconChoiceArr[3] = Icon4;

	}	

	public void ChooseRandomIcons() 
	{
		print ("enabled");

		foreach(IconChoice Icon in iconChoiceArr)
		{	
			// get a random number so we can access a random icon choice
			int index = Random.Range(0, Icon.choice.Count);
			Icon.currentIndex = index;
			Icon.startingChoice = Icon.choice[index];

			string tag = Icon.startingChoice.tag;

			// Get  reference to the currect Icon
			IconChoice currentIcon = Icon;
		
			
			//Icon currentIcon = Icon.Icon;

//			foreach(IconChoice i in iconChoiceArr)
//			{
//				if (i != currentIcon)
//				{
//					Image choiceToRemove = i.choice[index];
//					i.choice.Remove(choiceToRemove);
//				}
//			}

			foreach (Image choice in Icon.choice)
			{
				if (choice.GetInstanceID() != Icon.startingChoice.GetInstanceID())
					choice.color = GetVisibility(choice.color, false);
			}
			//Icon.startingChoice = Icon.choice
		}	
	}

	public void NextChoiceUp(RectTransform Icon)
	{
		//print (IconContainer.name);
		IconChoice iconChoice = GetIconChoice(Icon);
		int index = iconChoice.currentIndex + 1;

		if (WithinIndex(index))
		{
			AudioManager.Instance.PlayEffect(AudioManager.Clip.Click);

			iconChoice.startingChoice = iconChoice.choice[index];
			print ("icon choice is: " + iconChoice.startingChoice);

			iconChoice.currentIndex = index;

			foreach(Image choice in iconChoice.choice)
			{
				if (choice.GetInstanceID() != iconChoice.startingChoice.GetInstanceID())
					choice.color = GetVisibility(choice.color, false);
				else
					choice.color = GetVisibility(choice.color, true);
			}
		}


	}

	public void NextChoiceDown(RectTransform Icon)
	{
		IconChoice iconChoice = GetIconChoice(Icon);
		int index = iconChoice.currentIndex - 1;
		if (WithinIndex(index))
		{
			AudioManager.Instance.PlayEffect(AudioManager.Clip.Click);

			iconChoice.startingChoice = iconChoice.choice[index];
			print ("icon choice is: " + iconChoice.startingChoice);
			iconChoice.currentIndex = index;

			foreach(Image choice in iconChoice.choice)
			{
				if (choice.GetInstanceID() != iconChoice.startingChoice.GetInstanceID())
					choice.color = GetVisibility(choice.color, false);
				else
					choice.color = GetVisibility(choice.color, true);
			}
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IconChoice GetIconChoice(RectTransform icon)
	{
		foreach (IconChoice tile in iconChoiceArr)
		{
			if (tile.Icon.GetInstanceID() == icon.GetInstanceID())
			{
				return tile;
			}
		}

		Debug.LogError("Problem");
		return new IconChoice();
	}

	bool WithinIndex (int index)
	{
		return (index < 4 && index > 0);
	}

	Color GetVisibility(Color currentColor, bool visible)
	{
		float alpha = visible ? 1 : 0;
		return new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
	}

}

[System.Serializable]
 public class IconChoice
{
	public RectTransform Icon;
	public Image startingChoice;
	public int currentIndex;
	public List<Image> choice = new List<Image>();
}
