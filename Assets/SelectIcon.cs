using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectIcon : MonoBehaviour {
	public static SelectIcon Instance;

	public GameObject[] icons = new GameObject[4];
	public Sprite defaultSprite;
	public Sprite selectedSprite;
	private int currentSelectedIcon = 0;

	private Vector3 defaultScale;

	// Use this for initialization
	void Start () 
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(this);

		var firstIcon =	icons[0].GetComponent<Image>();
		firstIcon.sprite = selectedSprite;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameManager.Instance.IsInEncounter())
		{
			if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && currentSelectedIcon != 3)
			{
				print("hit right");
				currentSelectedIcon++;
				DeselectIcons();
				AudioManager.Instance.PlayEffect(AudioManager.Clip.TileSelect);	
			}
			else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && currentSelectedIcon != 0)
			{
				print("hit right");
				currentSelectedIcon--;
				DeselectIcons();
				AudioManager.Instance.PlayEffect(AudioManager.Clip.TileSelect);	
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
			{
				RectTransform iconRT = icons[currentSelectedIcon].GetComponent<RectTransform>();
				IconsInit.Instance.NextChoiceDown(iconRT);


				//AudioManager.Instance.PlayEffect(AudioManager.Clip.Click);	
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
			{
				RectTransform iconRT = icons[currentSelectedIcon].GetComponent<RectTransform>();
				IconsInit.Instance.NextChoiceUp(iconRT);
				//AudioManager.Instance.PlayEffect(AudioManager.Clip.Click);	

			}

		}

	}

	void DeselectIcons()
	{
		foreach(GameObject icon in icons)
		{
			if (icon.GetInstanceID() != icons[currentSelectedIcon].GetInstanceID())
			{
				icon.GetComponent<Image>().sprite = defaultSprite;
			}
			else
			{
				var theIcon = icon;
				LeanTween.scale(theIcon, Vector3.one * 1.1f, 0.1f).setOnComplete(() => {
					LeanTween.scale(theIcon, Vector3.one, 0.1f);
				});
				icon.GetComponent<Image>().sprite = selectedSprite;
			}
		}
	}

	public void MouseSelectIcon(int index)
	{
		print ("pressed icon");
		currentSelectedIcon = index;
		AudioManager.Instance.PlayEffect(AudioManager.Clip.TileSelect);	
		DeselectIcons();
	}

	public void DismissEncounterUI()
	{
		
	}
}
