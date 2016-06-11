using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//public PlayerController player;
	public static GameManager Instance;
	public static float v, h;

	// Use this for initialization
	void Awake () 
	{
		if(Instance == null)
			Instance = this;
		else 
			Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
