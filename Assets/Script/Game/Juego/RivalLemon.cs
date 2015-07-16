using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RivalLemon : MonoBehaviour {
    [HideInInspector]
    public Animator anim;
    public TextMesh name;
    private Vector3 nextPosition;
    private int posicion;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        name = GetComponentInChildren<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        if (name.text == Manager.gManager.jugador.nombre)
        {
			posicion = Manager.gManager.jugador.posicion*100;
            nextPosition = new Vector3(posicion, 0, 0);
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, nextPosition,0.005f);
	}
    public void setName(string n)
    {
        name.text = n;
    }
    public string getName()
    {
        return name.text;
    }
}
