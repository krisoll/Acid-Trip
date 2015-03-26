using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayRoad : MonoBehaviour {

    public float breakV = 0;
    private float posYInicial, posYFinal;
    private float diferencia;
    private bool detenido = true;
    private RawImage img;
	// Use this for initialization
	void Start () {
        img = GetComponent<RawImage>();
	}
    void FixedUpdate()
    {
        if (!detenido) diferencia -= breakV;
        Manager.gManager.lemon.currentVelocity = diferencia;
        Manager.gManager.city.velocidad = diferencia*0.1f;
    }
	// Update is called once per frame
	void Update () {
        //img.uvRect = new Rect(0,img.uvRect.y+0.1f,1,1);
        if (Input.GetMouseButtonDown(0))
        {
            posYInicial = Input.mousePosition.y*0.001f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            posYFinal = Input.mousePosition.y*0.001f;
            diferencia = posYInicial - posYFinal;
            detenido = false;
        }
        if (diferencia <= 0) { detenido = true; diferencia = 0; }
        img.uvRect = new Rect(0, img.uvRect.y + diferencia, 1, 1);
	}
}
