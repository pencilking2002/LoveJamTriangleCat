using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	//---------------------------------------------------------------------------------------------------------------------------
	// Public Variables
	//---------------------------------------------------------------------------------------------------------------------------

	public static InputController Instance;
	public static float h, v;

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
