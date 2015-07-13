using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SalaScreen : MonoBehaviour {
    public GameObject[] objetosJugador;
    public Text nombreSala;
    private int numJugadores = 0;
	// Use this for initialization
	void Start () {
        nombreSala.text = Manager.gManager.sala.nombre;
	}
	
	// Update is called once per frame
	void Update () {
        Manager.gManager.getSala(Manager.gManager.sala.nombre);
        if (numJugadores != Manager.gManager.sala.jugadores.Length)
        {
            ObtenerJugadores();
        }
	}
    void ObtenerJugadores()
    {
        for (int i = 0; i < Manager.gManager.sala.jugadores.Length; i++)
        {
            objetosJugador[i].SetActive(true);
            objetosJugador[i].GetComponentInChildren<Text>().text = Manager.gManager.sala.jugadores[i];
        }
        numJugadores = Manager.gManager.sala.jugadores.Length;
    }
}
