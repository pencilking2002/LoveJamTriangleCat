using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startMenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject panelQuote;
    [SerializeField]
    private GameObject panelRules;
    [SerializeField]
    private GameObject buttonStart;

    [SerializeField]
    private Color colorWhite;
    [SerializeField]
    private Color colorInvis;

    private float fadeTime;

	void Start () {
        fadeTime = Time.time + 4.0f;
	}

    public IEnumerator FadeTitles() {
        LeanTween.alpha(panelQuote.GetComponent<RectTransform>(), 0.0f, 0.6f);
        LeanTween.alpha(buttonStart.GetComponent<RectTransform>(), 1.0f, 0.6f);
        yield return new WaitForSeconds(8.0f);
        LeanTween.alpha(panelRules.GetComponent<RectTransform>(), 0.0f, 0.6f);
        yield return null;
    }

    public void clearAll() {
        panelQuote.SetActive(false);
        panelRules.SetActive(false);
        buttonStart.SetActive(false);
    }
	
	void Update () {
	    if (Time.time >= fadeTime) {
            StartCoroutine(FadeTitles());
        }
	}
}
