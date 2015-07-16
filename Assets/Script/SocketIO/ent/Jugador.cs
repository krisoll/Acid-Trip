using UnityEngine;
using System.Collections;

public class Jugador {

	public string id;
	public string nombre;
	public int posicion; 

	public Jugador(){}

	public Jugador(JSONObject jo){
		if(jo.IsArray)
			jo = jo.list[0];
		if (jo.GetField ("id") != null)
			id = jo.GetField ("id").ToString ().Replace("\"","");
		if (jo.GetField ("nombre") != null)
			nombre = jo.GetField ("nombre").ToString ().Replace("\"","");
		if (jo.GetField ("posicion") != null)
			posicion = int.Parse(jo.GetField ("posicion").ToString ().Replace("\"",""));
	}
}
