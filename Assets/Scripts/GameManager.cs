using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public bool testing;

	//---------------------------------------------------------------------------------------------------------------------------
	// Public Variables
	//---------------------------------------------------------------------------------------------------------------------------

	public Image IconContainer;
	public Vector3 initialPosition = Vector3.zero;

	//public PlayerController player;
	public static GameManager Instance;
	public static float v, h;

	[HideInInspector]
	public NPCController currentNPCController;
	 
	public enum State
	{
		Menu,
		WalkingAround,
		InEncounter,
		GameOver
	}
	State state = State.Menu;

	//---------------------------------------------------------------------------------------------------------------------------
	// Private Variables
	//---------------------------------------------------------------------------------------------------------------------------

	// Use this for initialization
	void Awake () {
		if(Instance == null)
			Instance = this;
		else 
			Destroy(this);

		if (testing)
			state = State.WalkingAround;

		initialPosition = IconContainer.GetComponent<RectTransform>().localPosition;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//inputDevice = InputManager.ActiveDevice;
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");

        if (Input.GetKeyDown(KeyCode.L) && state == State.Menu)
            beginGame();
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

	void OnGUI ()
	{
		GUI.Button(new Rect(10,10, 200,40), "GameObject State: " + state);
	}

	public void SetState(State s)
	{
		state = s;
	}

	public bool IsInMenu()
	{
		return state == State.Menu;
	}

	public bool IsWalkingAround()
	{
		return state == State.WalkingAround;
	}

	public bool IsInEncounter()
	{
		return state == State.InEncounter;
	}

	public bool IsGameOver()
	{
		return state == State.GameOver;
	}

    public void beginGame() {
        state = State.WalkingAround;
        GameObject.FindGameObjectWithTag("Player").GetComponent<VisMessageTrigger>().enabled = false;
        Camera.main.GetComponent<CamController>().cameraAdjustToGame();
    }

	public void EnableIconContainer(bool enable)
	{
		if (enable)
		{
			IconContainer.gameObject.SetActive(true);
			//IconContainer.transform.localScale = Vector3.zero;
			//LeanTween.moveX(IconContainer.gameObject, Vector3.one, scaleTweenTime).setEase(LeanTweenType.easeOutQuint);
			LeanTween.moveX(IconContainer.rectTransform, 0, 0.5f);
		}
		else
		{
			state = State.WalkingAround;

			LeanTween.moveX(IconContainer.rectTransform, initialPosition.x, 0.5f).setOnComplete(() =>
			{
				IconContainer.gameObject.SetActive(false);
				currentNPCController.EnableThoughtPanel(true);
			});
		}

	}

}
