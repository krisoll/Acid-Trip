using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayRoad : MonoBehaviour {

    public float breakV = 0;
    public GameObject objetoJugador;
    public GameObject contenedorPlayers;
    private float posYInicial, posYFinal;
    private float diferencia;
    private bool detenido = true;
    private RawImage img;
    private float distanciaRecorrida;
    private float diferenciaDistancia;
    private Vector3 posContenedorInicial;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < Manager.gManager.sala.jugadores.Length; i++)
        {
            if (Manager.gManager.sala.jugadores[i] != Manager.gManager.cli.getIdCliente())
            {
                GameObject g = (GameObject)Instantiate(objetoJugador, contenedorPlayers.transform.position, Quaternion.identity);
                g.GetComponent<RivalLemon>().setName(Manager.gManager.sala.jugadores[i]);
                Manager.gManager.rivales.Add(g.GetComponent<RivalLemon>());
                g.transform.SetParent(contenedorPlayers.transform);
            }         
        }
        posContenedorInicial = contenedorPlayers.transform.position;
            img = GetComponent<RawImage>();
            Manager.gManager.road = this;
	}
    
    void FixedUpdate()
    {
        if (!detenido)diferencia -= breakV;
        Manager.gManager.lemon.currentVelocity = diferencia;
        Manager.gManager.city.velocidad = diferencia*0.1f;
        distanciaRecorrida += diferencia*0.3f;
        contenedorPlayers.transform.position = new Vector2(contenedorPlayers.transform.position.x - diferencia, contenedorPlayers.transform.position.y);
        Manager.gManager.lemon.transform.position = posContenedorInicial;
    }
	// Update is called once per frame
	void Update () {
        if (Manager.gManager.finalizo) { Application.LoadLevel(4); Manager.gManager.finalizo = false; }
        if (distanciaRecorrida - diferenciaDistancia >= 1)
        {
            diferenciaDistancia = distanciaRecorrida;
            Manager.gManager.cli.correr();
        }
        //img.uvRect = new Rect(0,img.uvRect.y+0.1f,1,1);
        if (Input.GetMouseButtonDown(0))
        {
            posYInicial = Input.mousePosition.y*0.0005f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            posYFinal = Input.mousePosition.y*0.0005f;
            diferencia = posYInicial - posYFinal;
            detenido = false;
        }
        if (diferencia <= 0) { detenido = true; diferencia = 0; }
        img.uvRect = new Rect(0, img.uvRect.y + diferencia, 1, 1);
	}
}
