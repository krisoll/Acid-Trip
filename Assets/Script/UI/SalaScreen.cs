using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SalaScreen : MonoBehaviour {
    public GameObject[] objetosJugador;
    public Text nombreSala;
    private Sala sala;
	// Use this for initialization
	void Start () {
        sala = Manager.gManager.sala;
        nombreSala.text = sala.nombre;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void ObtenerJugadores()
    {

    }
}
