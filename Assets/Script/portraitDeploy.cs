using UnityEngine;
using System.Collections;

public class portraitDeploy : MonoBehaviour {
    public GameObject portraitPanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Deploy()
    {
        if (portraitPanel.activeInHierarchy) portraitPanel.SetActive(false);
        else portraitPanel.SetActive(true);
    }
}
