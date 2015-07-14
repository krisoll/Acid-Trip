using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class City : MonoBehaviour {

    [HideInInspector]
    public float velocidad;
    private RawImage img;
    // Use this for initialization
    void Start()
    {
        img = GetComponent<RawImage>();
        Manager.gManager.city = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (velocidad<= 0) velocidad = 0; 
        img.uvRect = new Rect(img.uvRect.x + velocidad,0, 1, 1);
    }
}
