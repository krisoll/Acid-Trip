using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sala{
	public string	nombre;
	public Jugador[] jugadores;
	public string 	clave;
	public int		distancia;
	public int		estado;

	public Sala(){}

	public Sala(JSONObject jo){
		if(jo.GetField ("nombre")!=null)
			nombre 		= jo.GetField ("nombre").ToString ().Replace("\"","");
		if (jo.GetField ("clave") != null) {
			clave = jo.GetField ("clave").ToString ().Replace ("\"", "");
			if(clave.ToLower().Equals("null"))
				clave = null;
		}
		if (jo.GetField ("distancia") != null)
			distancia = int.Parse(jo.GetField ("distancia").ToString ().Replace("\"",""));
		if(jo.GetField ("estado")!=null)
			estado 		= int.Parse(jo.GetField ("estado").ToString ().Replace("\"",""));
		if (jo.GetField ("jugadores") != null) {
			List<JSONObject> lista = jo.GetField ("jugadores").list;
			jugadores = new Jugador[lista.Count];
			for(int i=0;i<lista.Count;i++){
				jugadores[i] = new Jugador(lista[i]);
			}
		}
	}

}
