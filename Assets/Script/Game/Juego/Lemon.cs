using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Lemon : MonoBehaviour {
    [HideInInspector]
    public Animator anim;
    public TextMesh name;
    public Slider slide;
    public float currentVelocity;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        Manager.gManager.lemon = this;
        name = GetComponentInChildren<TextMesh>();
        setName(Manager.gManager.jugador.nombre.Substring(2));
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Velocity", currentVelocity);
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
