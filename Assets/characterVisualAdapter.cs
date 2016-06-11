using UnityEngine;
using System.Collections;

public class characterVisualAdapter : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer rendHead;
    [SerializeField]
    private SpriteRenderer rendBody;
    [SerializeField]
    private SpriteRenderer rendLegs;
    [SerializeField]
    private SpriteRenderer rendHandL;
    [SerializeField]
    private SpriteRenderer rendHandR;
    [SerializeField]
    private SpriteRenderer rendFace;
    [SerializeField]
    private SpriteRenderer rendHair;

    private int diffLeft;
    private int diffRight;

    void Start () {
        diffLeft = 2;
        diffRight = 2;
    }

    public void leftHandFront() {
        diffLeft = -2;
        diffRight = 2;
    }

    public void rightHandFront() {
        diffLeft = 2;
        diffRight = -2;
    }

    void newLayers() {
        rendBody.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100));
        rendLegs.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100)) + 1;
        rendHead.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100)) + 1;
        rendFace.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100)) + 2;
        rendHair.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100)) + 3;
        rendHandL.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100)) + diffLeft;
        rendHandR.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100)) + diffRight;
    }
	
	void Update () {
        newLayers();
	}
}
