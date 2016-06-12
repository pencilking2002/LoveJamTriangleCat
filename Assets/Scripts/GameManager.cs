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
	}
	
	// Update is called once per frame
	void Update () 
	{
		//inputDevice = InputManager.ActiveDevice;
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");

        if (Input.GetKeyDown(KeyCode.L))
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
        Camera.main.GetComponent<CamController>().cameraAdjustToGame();
    }



}
