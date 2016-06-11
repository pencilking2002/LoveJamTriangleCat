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
	private bool canMove = true;

	//---------------------------------------------------------------------------------------------------------------------------
	// Private Variables
	//---------------------------------------------------------------------------------------------------------------------------

	private Vector2 moveDirection = Vector3.zero;
	private Rigidbody2D rb;

	private Dictionary <string, Image> iconsDict = new Dictionary<string, Image>();
	private Dictionary <string, Sprite> hiddenIconSprites = new Dictionary<string, Sprite>();

	public Sprite hiddenIcon1;
	public Sprite hiddenIcon2;
	public Sprite hiddenIcon3;
	public Sprite hiddenIcon4;


	// Use this for initialization
	void Awake () 
	{
		rb = GetComponent<Rigidbody2D>();
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
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("npc"))
		{
			print ("collision");
			col.gameObject.GetComponent<NPCController>().EnableIconContainer();
		}

	}

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
