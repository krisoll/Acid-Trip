using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sala{
	public string	nombre;
	public string[] jugadores;
	public string 	clave;
	public string	distancia;
	public int		estado;

	public Sala(){}

	public Sala(JSONObject jo){
		if(jo.GetField ("nombre")!=null)
			nombre 		= jo.GetField ("nombre").ToString ();
		if(jo.GetField ("clave")!=null)
			clave 		= jo.GetField ("clave").ToString ();
		if (jo.GetField ("distancia") != null)
			distancia = jo.GetField ("distancia").ToString ();
		if(jo.GetField ("estado")!=null)
			estado 		= int.Parse(jo.GetField ("estado").ToString ());
		if (jo.GetField ("jugadores") != null) {
			jo = jo.GetField ("jugadores");
			List<JSONObject> lista = jo.list;
			jugadores = new string[lista.Count];
			for(int i=0;i<lista.Count;i++){
				jugadores[i] = lista[i].ToString();
			}
		}
	}

}
