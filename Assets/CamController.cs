﻿using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {
	public Vector3 offset = new Vector3(10, 10, 0);
	public Transform player;
	public float moveDamp = 0.5f;

	private Vector3 moveVel;

	// Use this for initialization
	void Awake () 
	{
		if (player == null)
			Debug.LogError("Player is not attached to camera CamController");
	}

	// Update is called once per frame
	void LateUpdate () 
	{	
		var targetPos = new Vector3(player.position.x, player.position.y, transform.position.z) + offset;
		transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref moveVel, moveDamp);
	}
}