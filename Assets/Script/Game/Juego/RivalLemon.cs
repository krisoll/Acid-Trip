using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RivalLemon : MonoBehaviour {
    [HideInInspector]
    public Animator anim;
    public TextMesh nombre;
    public Slider slider;
    private Vector3 nextPosition;
	private Jugador jugador;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        nombre = GetComponentInChildren<TextMesh>();
        nombre.text = jugador.nombre.Substring(2);
    }
	
	// Update is called once per frame
	void Update () {
		if (jugador != null && jugador.id == Manager.gManager.idJugador)
        {
            jugador.posicion = Manager.gManager.posicion * 70;
			nextPosition = new Vector3(jugador.posicion, transform.position.y,transform.position.z);
            slider.value = Manager.gManager.posicion;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, nextPosition,0.02f);
    }

	public void setJugador(Jugador jugador){
		this.jugador = jugador;
	}

	public Jugador getJugador(){
		return this.jugador;
	}
}
