using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RivalLemon : MonoBehaviour {
    [HideInInspector]
    public Animator anim;
    public TextMesh name;
    public Slider slider;
    private Vector3 nextPosition;
	private Jugador jugador;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (jugador != null && jugador.id == Manager.gManager.idJugador)
        {
            jugador.posicion = Manager.gManager.posicion * 70;
			nextPosition = new Vector3(jugador.posicion, transform.position.y,transform.position.z);
            slider.value = jugador.posicion;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, nextPosition,0.007f);
	}

	public void setJugador(Jugador jugador){
		this.jugador = jugador;
		name.text = jugador.nombre;
	}

	public Jugador getJugador(){
		return this.jugador;
	}
}
