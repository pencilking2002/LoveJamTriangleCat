using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectIcon : MonoBehaviour {
	public static SelectIcon Instance;

	public GameObject[] icons = new GameObject[4];
	public Sprite defaultSprite;
	public Sprite selectedSprite;
	private int currentSelectedIcon = 0;

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
			if (Input.GetKeyDown(KeyCode.RightArrow) && currentSelectedIcon != 3)
			{
				print("hit right");
				currentSelectedIcon++;
				DeselectIcons();
				AudioManager.Instance.PlayEffect(AudioManager.Clip.TileSelect);	
			}
			else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentSelectedIcon != 0)
			{
				print("hit right");
				currentSelectedIcon--;
				DeselectIcons();
				AudioManager.Instance.PlayEffect(AudioManager.Clip.TileSelect);	
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
				icon.GetComponent<Image>().sprite = selectedSprite;
			}
		}
	}
}
