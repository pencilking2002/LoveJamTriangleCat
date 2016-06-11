using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10.0f;

	private Vector2 moveDirection = Vector3.zero;
	private Rigidbody2D rb;

	// Use this for initialization
	void Awake () 
	{
		rb = GetComponent<Rigidbody2D>();
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
		}

	}
}
