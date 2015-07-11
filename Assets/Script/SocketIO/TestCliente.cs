using UnityEngine;
using System.Collections;

public class TestCliente : MonoBehaviour {

	private Cliente cli;

	void Start () {
		cli = new Cliente ();
		cli.onConectado += () => {
			Debug.Log("Conectado :D");
			Sala sala 		= new Sala();
			sala.nombre 	= "Sala desde C#";
			sala.distancia 	= "3000";
			sala.clave 		= null;
			cli.crearSala(sala);
			//sala.nombre 	= "s1";
			//Para unirse el objeto sala tiene como parametro obligatorio el atributo nombre
			//cli.unirse(sala);
		};

		cli.onError += (error) => {
			Debug.LogError(error);
		};

		cli.onSalas += (salas) => {
			Debug.Log("Cantidad de salas = "+salas.Count);
			foreach(Sala sala in salas)
				Debug.Log(sala.nombre+" > "+sala.distancia+" > "+sala.jugadores.Length+" > "+sala.estado);
		};
		
		cli.onCrearSala += (estado, error) => {
			if(estado)
				Debug.Log("Sala creada");
			else
				Debug.LogError("Error al crear sala: "+error);
		};
		
		cli.onUnirse += (estado, error) => {
			if(estado)
				Debug.Log("Unido a la sala");
			else
				Debug.LogError("Error al unirse: "+error);
		};

		cli.onIniciarCarrera += (sala) => {
			Debug.Log("Inicio la carrera en la sala : "+sala.nombre);
			cli.correr();
		};

		cli.onPosiciones += (idJugador, posicion) => {
			Debug.Log("JUGADOR "+idJugador+" >> "+posicion);
		};

		cli.onJugadorDesconectado += (idJugador) => {
			Debug.Log("JUGADOR DESCONECTADO "+idJugador);
		};

		cli.onCarreraTerminada += (idJugadorGanador) => {
			Debug.Log("JUGADOR GANADOR "+idJugadorGanador);
		};

		cli.onSalaCerrada += (sala) => {
			Debug.LogError("Sala Cerrada: "+sala.nombre);
		};

		cli.conectar ();
	}

	void OnDestroy () {
		if (cli != null)
			cli.cerrar ();
	}
}
