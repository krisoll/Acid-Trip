using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cliente : MonoBehaviour
{

    SocketIOClient.Client socket;

    void Start()
    {

        socket = new SocketIOClient.Client("https://acid-trip.herokuapp.com");
        socket.On("connect", (fn) =>
        {
            socket.On("salas", (fn)=>
            {
                listaSalas(fn);
            }),
            socket.On("resultado_crear_sala", (a)=>
            {
                resultadoCrearSala(a)
            }
            ),
            socket.On("resultado_unirse_sala", (a)=>
            {
                resultadoUnirse(a)
            }),
            socket.On("iniciar_carrera",(a)=>
            {
                inicioCarrera(a)
            }),
            socket.On("resultado_iniciar_carrera", (a)=>
            {
                resultadoIniciarCarrera(a)
            }),
            socket.On("posiciones", (a,o)=>
            {
                actualizarPoscion(a, o)
            }),
            socket.On("carrera_terminada", (a)=>
            {
                carreraTeminada(a)
            }),
            socket.On("jugador_desconectado", (a)=>
            {
                jugadorDesconectado(a)
            }),
            socket.On("sala_cerrada", (fn)
            {
                salaCerrada()
            })
        });
        socket.On("RECV", (data) =>
        {
            Debug.Log(data.Json.ToJsonString());
        });
        socket.Error += (sender, e) =>
        {
            Debug.Log("socket Error: " + e.Message.ToString());
        };
        socket.Connect();
    }

    void Update()
    {

    }

    void OnGUI()
    {

        if (GUI.Button(new Rect(20, 70, 150, 30), "SEND"))
        {
            Debug.Log("Sending");

            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("msg", "hello!");
            socket.Emit("SEND", args);
        }

        if (GUI.Button(new Rect(20, 120, 150, 30), "Close Connection"))
        {
            Debug.Log("Closing");

            socket.Close();
        }
    }
    void listaSalas(ArrayList Sala){
	//La variable sala es un Array<Sala>
    }

    void crear_sala(string nombre, string distancia, string clave){
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("nombre",nombre);
            args.Add("distancia",distancia);
            args.Add("clave",clave);
	        socket.Emit("crear_sala", args);
	//Es obvio no?
    }

    void resultadoCrearSala(string respuesta){
	    //En caso de error respuesta.estado != 0
	    //El detalle del error se encuentra en respuesta.resultado
    }

    void unirse(string nombre){
	    socket.Emit("unirse_sala", nombre);
	    //Es obvio no?
    }

    void resultadoUnirse(string respuesta){
	    //En caso de error respuesta.estado != 0
	    //El detalle del error se encuentra en respuesta.resultado
    }

    void iniciar_carrera(){
	    socket.Emit("inicar_carrera","");
	    //Este metodo es invocado cuando el dueño de la sala decide iniciar la carrera
    }

    void resultadoIniciarCarrera(string respuesta){
	    //En caso de error respuesta.estado != 0
	    //El detalle del error se encuentra en respuesta.resultado
    }

    void inicioCarrera(string sala){
	    //Este metodo es disparado cuando el dueño de la sala inicia la carrera
	    //El objeto recibido es de tipo Sala con sus respectivo valores
    }

    void correr(){
	    socket.Emit("correr","");
	    //Este metodo es invocado para informar al servidor que el jugador esta corriendo
    }

    void actualizarPoscion(string idJugador,string posicion){
	    //Este metodo es invocado desde el servidor cada vez que un jugador actualiza su posicion
    }

    void carreraTeminada(string idJugador){
	    //Este metodo es invocado desde el servidor cuando un jugador a alcanzado la meta e indica el id del ganador
    }

    void jugadorDesconectado(string idJugador){
	    //Este metodo es invocado cuando un jugador deja la sala y la carrera
    }

    void salaCerrada(){
	    //Este metodo es invocado cuando la sala se cierra por salida del jugador creador de la sala
    }
}


