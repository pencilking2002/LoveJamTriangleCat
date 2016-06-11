using UnityEngine;
using System.Collections;

public class characterRandom : MonoBehaviour {

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
    private Transform containerFace;
    [SerializeField]
    private SpriteRenderer rendHair;
    [SerializeField]
    private Transform containerHair;
    [SerializeField]
    private SpriteRenderer rendHairBack;

    [SerializeField]
    private Sprite[] spritesFace;
    [SerializeField]
    private Sprite[] spritesHair;
    [SerializeField]
    private Sprite[] spritesHairBack;

    [SerializeField]
    private Gradient gradientSkin;
    [SerializeField]
    private Gradient gradientBody;
    [SerializeField]
    private Gradient gradientLegs;
    [SerializeField]
    private Gradient gradientHair;

    void Start () {
	
	}

    void randomizeAll() {
        float skinValue = Random.Range(0.0f, 1.0f);
        float hairValue = Random.Range(0.0f, 1.0f);
        int hairScale = (Random.Range(0, 1) * 2) - 1;
        containerHair.localScale = new Vector3(hairScale, 1, 1);
        int faceScale = (Random.Range(0, 1) * 2) - 1;
        containerFace.localScale = new Vector3(faceScale, 1, 1);
        rendHead.color = gradientSkin.Evaluate(skinValue);
        rendHandL.color = gradientSkin.Evaluate(skinValue);
        rendHandR.color = gradientSkin.Evaluate(skinValue);
        rendFace.sprite = spritesFace[Random.Range(0, spritesFace.Length)];
        rendHair.sprite = spritesHair[Random.Range(0, spritesHair.Length)];
        rendHairBack.sprite = spritesHairBack[Random.Range(0, spritesHairBack.Length)];
        rendHair.color = gradientHair.Evaluate(hairValue);
        rendHairBack.color = gradientHair.Evaluate(hairValue);
        rendBody.color = gradientBody.Evaluate(Random.Range(0.0f, 1.0f));
        rendLegs.color = gradientLegs.Evaluate(Random.Range(0.0f, 1.0f));
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
            randomizeAll();

	}
}
