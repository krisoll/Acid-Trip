﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Manager : MonoBehaviour {
    [HideInInspector]
    public Lemon lemon;
    [HideInInspector]
    public PlayRoad road;
    [HideInInspector]
    public City city;
    public Sala sala;
    public string idJugador;
    public int posicion;
    public Cliente cli;
    public List<Sala> salas = new List<Sala>();
    public List<RivalLemon> rivales = new List<RivalLemon>();
    public string ganador;
    public bool finalizo;
    public bool hayNuevasSalas = false;
    public static Manager gManager;
    public bool admin = false;
    public bool carreraIniciada = false;
	// Use this for initialization
    void Awake()
    {
        gManager = this;
        cli = new Cliente();
        cli.onConectado += () =>
        {
            Debug.Log("Conectado :D");
        };

        cli.onError += (error) =>
        {
            Debug.LogError(error);
        };

        cli.onSalas += (salas) =>
        {
            this.salas = salas;
            hayNuevasSalas = true;
            Debug.Log("Cantidad de salas = " + salas.Count);
        };

        cli.onCrearSala += (estado, error) =>
        {
            if (estado)
                Debug.Log("Sala creada");
            else
                Debug.LogError("Error al crear sala: " + error);
        };
        cli.onIniciarCarrera += (sala) =>
        {
            Debug.Log("Inicio la carrera en la sala : " + sala.nombre);
            carreraIniciada = true;
        };

        cli.onPosiciones += (idJugador, posicion) =>
        {
            this.idJugador = idJugador;
            this.posicion = posicion;
                Debug.Log("JUGADOR " + idJugador + " >> " + posicion);
        };

        cli.onJugadorDesconectado += (idJugador) =>
        {
            Debug.Log("JUGADOR DESCONECTADO " + idJugador);
        };

        cli.onCarreraTerminada += (idJugadorGanador) =>
        {
            ganador = idJugadorGanador;
            finalizo = true;
            Debug.Log("JUGADOR GANADOR " + idJugadorGanador);
        };

        cli.onSalaCerrada += (sala) =>
        {
            Debug.LogError("Sala Cerrada: " + sala.nombre);
        };

        cli.conectar();
    }
    void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void LoadLevel(int level)
    {
        Application.LoadLevel(level);
    }
    public void getSala(string name)
    {
        foreach (Sala sala in salas)
        {
            if (name == sala.nombre)
            {
                Manager.gManager.sala = sala;
            }
        }
    }
    void OnDestroy()
    {
        if (cli != null)
            cli.cerrar();
    }
    public void IniciarConexion()
    {
        if (cli != null) cli.conectar();
    }
    public void CerrarConexion()
    {
        if (cli != null) cli.cerrar();
    }
}
