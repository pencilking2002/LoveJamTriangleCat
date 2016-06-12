using UnityEngine;
using System.Collections;

public class environmentPlacement : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer render;

    [SerializeField]
    private Sprite[] possibleSprites;

	void Start () {
        render.sprite = possibleSprites[Random.Range(0, possibleSprites.Length)];
        render.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100));
    }
	
	void Update () {
	
	}
}
