using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Live_Indicator : MonoBehaviour {

	public Sprite[] images;

	private Image imageScript;

	private RectTransform canvasRectTransform;
    private RectTransform panelRectTransform;


    void Awake () {
        Canvas canvas = GetComponentInParent <Canvas>();
        if (canvas != null) {
            canvasRectTransform = canvas.transform as RectTransform;
            panelRectTransform = transform.parent as RectTransform;
			panelRectTransform.sizeDelta = new Vector2 (1920, 1080);
        }
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
