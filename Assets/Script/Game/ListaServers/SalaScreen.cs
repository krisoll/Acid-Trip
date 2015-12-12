using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SalaScreen : MonoBehaviour {
    public GameObject[] objetosJugador;
    public Text nombreSala;
    public GameObject botonIniciar;
    private int numJugadores = 0;
	// Use this for initialization
	void Start () {
        nombreSala.text = Manager.gManager.sala.nombre;
        if (Manager.gManager.admin) botonIniciar.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        Manager.gManager.getSala(Manager.gManager.sala.nombre);
        if (numJugadores != Manager.gManager.sala.jugadores.Length)
        {
            ObtenerJugadores();
        }
        if (Manager.gManager.carreraIniciada)
        {
            Application.LoadLevel(3);
        }
	}
    void ObtenerJugadores()
    {
        for (int i = 0; i < Manager.gManager.sala.jugadores.Length; i++)
        {
            string split = Manager.gManager.sala.jugadores[i].nombre.Substring(0, 2);
            string rName = Manager.gManager.sala.jugadores[i].nombre.Substring(2);
            objetosJugador[i].SetActive(true);
            objetosJugador[i].GetComponent<Image>().sprite = Manager.gManager.playerR.getReference(split);
            objetosJugador[i].GetComponentInChildren<Text>().text = rName;
        }
        numJugadores = Manager.gManager.sala.jugadores.Length;
    }
}
