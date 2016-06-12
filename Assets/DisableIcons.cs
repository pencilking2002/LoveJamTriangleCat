using UnityEngine;
using System.Collections;

public class DisableIcons : MonoBehaviour {

	public bool disable = true;
	public GameObject[] icons = new GameObject[4];

	// Use this for initialization
	void Start () 
	{
		if (disable)
		{
			foreach(GameObject i in icons)
				i.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
