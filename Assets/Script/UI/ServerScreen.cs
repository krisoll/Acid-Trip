using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class ServerScreen : MonoBehaviour {
    public GameObject Panel;
    public GameObject salaPrefab;
    private Cliente cli;
    private List<Sala> salas = new List<Sala>();
	private bool hayNuevasSalas = false;
    void Start()
    {
        cli = new Cliente();
        cli.onConectado += () =>
        {
            Debug.Log("Conectado :D");
            Sala sala = new Sala();
            sala.nombre = "Sala desde C";
            sala.distancia = "3000";
            sala.clave = null;
            cli.crearSala(sala);
            //sala.nombre 	= "s1";
            //Para unirse el objeto sala tiene como parametro obligatorio el atributo nombre
            //cli.unirse(sala);
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

        cli.onUnirse += (estado, error) =>
        {
            if (estado)
                Debug.Log("Unido a la sala");
            else
                Debug.LogError("Error al unirse: " + error);
        };

        cli.onIniciarCarrera += (sala) =>
        {
            Debug.Log("Inicio la carrera en la sala : " + sala.nombre);
            cli.correr();
        };

        cli.onPosiciones += (idJugador, posicion) =>
        {
            Debug.Log("JUGADOR " + idJugador + " >> " + posicion);
        };

        cli.onJugadorDesconectado += (idJugador) =>
        {
            Debug.Log("JUGADOR DESCONECTADO " + idJugador);
        };

        cli.onCarreraTerminada += (idJugadorGanador) =>
        {
            Debug.Log("JUGADOR GANADOR " + idJugadorGanador);
        };

        cli.onSalaCerrada += (sala) =>
        {
            Debug.LogError("Sala Cerrada: " + sala.nombre);
        };

        cli.conectar();
    }

	void Update(){
		GetSalas ();
	}

    void GetSalas()
    {
		if (!hayNuevasSalas)
			return;
        float ySize = 0;
        foreach (Sala sala in salas)
        {
            GameObject g = (GameObject)Instantiate(salaPrefab, Panel.transform.position, Quaternion.identity);
            g.GetComponent<ServerButton>().sala = sala;
            g.GetComponent<ServerButton>().cli = cli;
            g.transform.parent = Panel.transform;
            g.transform.localScale = salaPrefab.transform.localScale;
            g.transform.localPosition = new Vector3(0, ySize, 0);
            ySize -= -40f;
            Text t = g.GetComponentInChildren<Text>();
            t.text = sala.nombre +" x "+ sala.distancia + " > " + sala.jugadores.Length + " > " + sala.estado;
        }
		hayNuevasSalas = false;
    }
    void OnDestroy()
    {
        if (cli != null)
            cli.cerrar();
    }
}
