using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIOClient;

public class Cliente {
	
	public delegate void mConectado();
	public delegate void mError(string error);
	public delegate void mSalas(List<Sala> salas);
	public delegate void mCrearSala(bool estado, string error);
	public delegate void mUnirse(bool estado, string error);
	public delegate void mIniciarCarrera(Sala sala);
	public delegate void mResultadoIniciarCarrera(bool estado, string error);
	public delegate void mPosiciones(Jugador jugador);
	public delegate void mCarreraTerminada(Jugador ganador);
	public delegate void mJugadorDesconectado(Jugador jugador);
	public delegate void mSalaCerrada(Sala sala);

	private Client socket;
	
	public mConectado 				onConectado;
	public mError 					onError;
	public mSalas 					onSalas;
	public mCrearSala				onCrearSala;
	public mUnirse					onUnirse;
	public mIniciarCarrera			onIniciarCarrera;
	public mResultadoIniciarCarrera	onResultadoIniciarCarrera;
	public mPosiciones				onPosiciones;
	public mCarreraTerminada		onCarreraTerminada;
	public mJugadorDesconectado		onJugadorDesconectado;
	public mSalaCerrada				onSalaCerrada;

	private Jugador jugador;
	
	public Cliente(){
		socket = new SocketIOClient.Client("http://acid-trip.herokuapp.com");
		socket.On ("connect", (fn) => {if(onConectado!=null){onConectado();socket.Emit("nombreJugador", jugador.nombre);}});
		socket.Error += (sender, e) => {if(onError!=null)onError(e.Message.ToString());};
		socket.On ("salas", (data) => {try{JSONObject datos = getArgumentos(data.MessageText)[0];List<Sala> salas = new List<Sala>();foreach(JSONObject jo in datos.list)salas.Add(new Sala(jo));if(onSalas!=null)onSalas(salas);}catch(System.Exception ex){if(onError!=null)onError(ex.Message);}});
		socket.On ("resultado_crear_sala", (data)=>{bool estado = true;string error = null;try{JSONObject jo = getArgumentos(data.MessageText)[0];int est = int.Parse(jo.GetField("estado").ToString());if(est!=0)throw new System.Exception(jo.GetField("resultado").ToString());}catch(System.Exception ex){estado = false;error = ex.Message;}if(onCrearSala!=null)onCrearSala(estado, error);});
		socket.On ("resultado_unirse_sala", (data)=>{bool estado = true;string error = null;try{JSONObject jo = getArgumentos(data.MessageText)[0];int est = int.Parse(jo.GetField("estado").ToString());if(est!=0)throw new System.Exception(jo.GetField("resultado").ToString());}catch(System.Exception ex){estado = false;error = ex.Message;}if(onUnirse!=null)onUnirse(estado, error);});
		socket.On ("iniciar_carrera", (data)=>{JSONObject jo = getArgumentos(data.MessageText)[0];Sala sala = new Sala(jo);if(onIniciarCarrera!=null)onIniciarCarrera(sala);});
		socket.On ("resultado_iniciar_carrera", (data)=>{bool estado = true;string error = null;try{JSONObject jo = getArgumentos(data.MessageText)[0];int est = int.Parse(jo.GetField("estado").ToString());if(est!=0)throw new System.Exception(jo.GetField("resultado").ToString());}catch(System.Exception ex){estado = false;error = ex.Message;}if(onResultadoIniciarCarrera!=null)onResultadoIniciarCarrera(estado, error);});
        socket.On ("posiciones", (data) => { JSONObject jo = getArgumentos(data.MessageText);Jugador jugador = new Jugador(jo);if (onPosiciones != null)onPosiciones(jugador); });
		socket.On ("carrera_terminada", (data)=>{ JSONObject jo = getArgumentos(data.MessageText);Jugador ganador = new Jugador(jo);if(onCarreraTerminada!=null)onCarreraTerminada(ganador);});
		socket.On ("jugador_desconectado", (data)=>{JSONObject jo = getArgumentos(data.MessageText);Jugador jugador = new Jugador(jo);if(onJugadorDesconectado!=null)onJugadorDesconectado(jugador);});
		socket.On ("sala_cerrada", (data)=>{JSONObject jo = getArgumentos(data.MessageText)[0];Sala sala = new Sala(jo);if(onSalaCerrada!=null)onSalaCerrada(sala);});
	}

	public void setNombre(string nombre){
		if (socket != null) {
			socket.Emit ("nombreJugador", nombre);
		}
	}

	public string getIdCliente(){
		return socket.HandShake.SID;
	}

	private JSONObject getArgumentos(string json){
		JSONObject jo 	= new JSONObject(json);
		jo = jo.GetField("args");
		return jo;
	}
	
	public void conectar(Jugador jugador){
		if (socket != null) {
			this.jugador = jugador;
			socket.Connect ();
		}
	}

	public void crearSala(Sala sala){
		if(socket!=null && socket.IsConnected)
			socket.Emit ("crear_sala", sala);
	}

	public void unirse(Sala sala){
		if (socket != null && socket.IsConnected)
			socket.Emit ("unirse_sala", sala);
	}
	
	public void iniciarCarrera(){
		if (socket != null && socket.IsConnected)
			socket.Emit ("inicar_carrera", null);
	}
	
	public void correr(){
		if (socket != null && socket.IsConnected)
			socket.Emit ("correr", null);
	}

	public void cerrar(){
		if (socket != null)
			socket.Close ();
	}


}
