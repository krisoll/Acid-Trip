using UnityEngine;
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
    public Cliente cli;
	public Jugador jugador = new Jugador();
    public List<Sala> salas = new List<Sala>();
    public List<RivalLemon> rivales = new List<RivalLemon>();
    public Jugador ganador;
    public bool finalizo;
    public bool hayNuevasSalas = false;
    public static Manager gManager;
    public bool admin = false;
    public bool carreraIniciada = false;
	// Use this for initialization
    void Awake()
    {
		this.jugador.nombre = "Nombre del jugador";
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

        cli.onPosiciones += (jugador) =>
		{
			Debug.Log("idJugador = "+jugador.id);
			Debug.Log("posicion = "+jugador.posicion);
            //this.idJugador = idJugador;
            //this.posicion = posicion;
              //  Debug.Log("JUGADOR " + idJugador + " >> " + posicion);
        };

        cli.onJugadorDesconectado += (jugador) =>
        {
			Debug.Log("JUGADOR DESCONECTADO " + jugador.id);
        };

        cli.onCarreraTerminada += (ganador) =>
        {
			this.ganador = ganador;
            finalizo = true;
			Debug.Log("JUGADOR GANADOR " + ganador.nombre +" ( "+ganador.id+")");
        };

        cli.onSalaCerrada += (sala) =>
        {
            Debug.LogError("Sala Cerrada: " + sala.nombre);
        };

		cli.conectar(this.jugador);
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
		if (cli != null) cli.conectar(this.jugador);
    }
    public void CerrarConexion()
    {
        if (cli != null) cli.cerrar();
    }
}
