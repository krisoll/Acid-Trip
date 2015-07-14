using UnityEngine;
using System.Collections;

public class Lemon : MonoBehaviour {
    [HideInInspector]
    public Animator anim;
    public float currentVelocity;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        Manager.gManager.lemon = this;
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Velocity", currentVelocity);
	}
}
