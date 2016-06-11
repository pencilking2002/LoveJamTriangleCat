using UnityEngine;
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

	private Vector2 moveDirection = Vector3.zero;
	private Rigidbody2D rb;

	private Dictionary <string, Image> iconsDict = new Dictionary<string, Image>();

	// Use this for initialization
	void Awake () 
	{
		rb = GetComponent<Rigidbody2D>();
		GameManager.CacheIcons(iconsDict, IconContainer);
	}

	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		MovePlayer();
	}

	void MovePlayer()
	{
		// Create a vector based on the player's input
		moveDirection = new Vector2(InputController.h, InputController.v);
		moveDirection = Vector2.ClampMagnitude(moveDirection, 1.0f);
		rb.velocity = moveDirection * moveSpeed;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("npc"))
		{
			print ("collision");
			col.gameObject.GetComponent<NPCController>().EnableIconContainer();
		}

	}
}
