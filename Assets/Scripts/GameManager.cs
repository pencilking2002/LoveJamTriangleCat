using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	//---------------------------------------------------------------------------------------------------------------------------
	// Priate Variables
	//---------------------------------------------------------------------------------------------------------------------------

	//public PlayerController player;
	public static GameManager Instance;
	public static float v, h;


	//---------------------------------------------------------------------------------------------------------------------------
	// Priate Variables
	//---------------------------------------------------------------------------------------------------------------------------
	[HideInInspector]
	//public InputDevice inputDevice;

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
}
