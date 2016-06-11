using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public static InputController Instance;

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
	
	}
}
