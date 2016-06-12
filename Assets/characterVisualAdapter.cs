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
    [SerializeField]
    private SpriteRenderer rendHairBack;

    private int diffLeft;
    private int diffRight;

    private int faceDiff;
    private int hairDiff;
    private int hairBackDiff;

    void Start () {
        diffLeft = 2;
        diffRight = 2;
        facingForward();
    }

    public void leftHandFront() {
        diffLeft = -2;
        diffRight = 2;
    }

    public void rightHandFront() {
        diffLeft = 2;
        diffRight = -2;
    }

    public void facingForward() {
        faceDiff = 2;
        hairDiff = 3;
        hairBackDiff = 0;
    }

    public void facingBack() {
        faceDiff = 0;
        hairDiff = 0;
        hairBackDiff = 2;
    }

    void newLayers() {
        rendBody.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100));
        rendHairBack.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100)) + hairBackDiff;
        rendLegs.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100)) + 1;
        rendHead.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100)) + 1;
        rendFace.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100)) + faceDiff;
        rendHair.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100)) + hairDiff;
        rendHandL.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100)) + diffLeft;
        rendHandR.sortingOrder = (Mathf.RoundToInt(transform.position.y * -100)) + diffRight;
    }
	
	void Update () {
        newLayers();
	}
}
