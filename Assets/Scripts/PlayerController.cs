﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//---------------------------------------------------------------------------------------------------------------------------
	// Public Variables
	//---------------------------------------------------------------------------------------------------------------------------

	public float moveSpeed = 10.0f;
	public Image IconContainer;

	//---------------------------------------------------------------------------------------------------------------------------
	// Private Variables
	//---------------------------------------------------------------------------------------------------------------------------
	private bool canMove = true;
	private Vector2 moveDirection = Vector3.zero;
	private Rigidbody2D rb;
	private Animator animator;

	private Dictionary <string, Image> iconsDict = new Dictionary<string, Image>();
	private Dictionary <string, Sprite> hiddenIconSprites = new Dictionary<string, Sprite>();

	public Sprite hiddenIcon1;
	public Sprite hiddenIcon2;
	public Sprite hiddenIcon3;
	public Sprite hiddenIcon4;

	private int anim_moveDirection = Animator.StringToHash("moveDirection");

	// Use this for initialization
	void Awake () 
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		GameManager.CacheIcons(iconsDict, IconContainer);
		CacheHiddenIconSprites();
		//ObfuscateIcons();
	}

	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (canMove)
		{
			MovePlayer();
		}
	}

	void MovePlayer()
	{
		// Create a vector based on the player's input
		moveDirection = new Vector2(InputController.h, InputController.v);
		moveDirection = Vector2.ClampMagnitude(moveDirection, 1.0f);
		rb.velocity = moveDirection * moveSpeed;

		// Going right
		if (InputController.h > 0)
		{
			animator.SetInteger(anim_moveDirection, 3);
		}
		// Going left
		else if (InputController.h < 0)
		{
			animator.SetInteger(anim_moveDirection, 1);
		}
		// Going up or down
		else if (Mathf.Abs(InputController.v) > 0)
		{
			animator.SetInteger(anim_moveDirection, 2);
		} 
		// else Idle
		else 
		{
			animator.SetInteger(anim_moveDirection, 0);
		}
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("npc"))
		{
			print ("collision");
			canMove = false;
			col.gameObject.GetComponent<NPCController>().EnableIconContainer();
		}

	}

	// Change 
	void RevealIcon(Image icon)
	{
		string iconTag = icon.tag;
		icon.sprite = hiddenIconSprites[icon.tag];
	}

	void CacheHiddenIconSprites()
	{
		hiddenIconSprites.Add("PlayerIcon1", hiddenIcon1);
		hiddenIconSprites.Add("PlayerIcon2", hiddenIcon2);
		hiddenIconSprites.Add("PlayerIcon3", hiddenIcon3);
		hiddenIconSprites.Add("PlayerIcon4", hiddenIcon4);

	}
}