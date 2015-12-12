using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PortraitSelect : MonoBehaviour {
    public string selectedSkin;
    public Image Portrait;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void selectSkin(string selectSkin)
    {
        selectedSkin = selectSkin;
    }
    public void selectImage(Sprite spr)
    {
        Portrait.sprite = spr;
        this.gameObject.SetActive(false);
    }
}
