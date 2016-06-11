using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public static InputController Instance;
	//PlayerActions playerActions;
	//PlayerActionSet playerActions;

	public static float h, v;

	//InputDevice device;


	// Use this for initialization
	void Awake () 
	{
		if(Instance == null)
			Instance = this;
		else 
			Destroy(this);
	}


	void OnEnable()
	{
		// See PlayerActions.cs for this setup.
		//playerActions = PlayerActionSet.CreateWithDefaultBindings();
	}
	// Update is called once per frame
	void Update () 
	{
		//device = InputManager.ActiveDevice;
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
	}
}
