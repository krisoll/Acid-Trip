﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RivalLemon : MonoBehaviour {
    [HideInInspector]
    public Animator anim;
    public TextMesh name;
    private Vector3 nextPosition;
	private Jugador jugador;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        name = GetComponentInChildren<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if (jugador != null && jugador.id == Manager.gManager.jugador.id)
        {
			jugador.posicion = Manager.gManager.jugador.posicion*100;
			nextPosition = new Vector3(jugador.posicion, 0, 0);
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, nextPosition,0.005f);
	}

	public void setJugador(Jugador jugador){
		this.jugador = jugador;
		name.text = jugador.nombre;
	}

	public Jugador getJugador(){
		return this.jugador;
	}
}
