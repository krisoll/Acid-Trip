using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayRoad : MonoBehaviour {

    public float breakV = 0;
    public GameObject contenedorPlayers;
    public GameObject contenedorSliders;
    public GameObject sliderPlayer;
    public GameObject sliderRival;
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
            GameObject g = null;
            GameObject s = null;
            GameObject objJugador = Manager.gManager.playerR.getPrefab(Manager.gManager.sala.jugadores[i].nombre.Substring(0,2));
            g = (GameObject)Instantiate(objJugador, contenedorPlayers.transform.position, Quaternion.identity);
            if (Manager.gManager.sala.jugadores[i].id != Manager.gManager.cli.getIdCliente())
            {
                s = (GameObject)Instantiate(sliderRival, contenedorPlayers.transform.position, Quaternion.identity);
                RivalLemon r = g.AddComponent<RivalLemon>();
				r.setJugador(Manager.gManager.sala.jugadores[i]);
                r.name = GetComponentInChildren<TextMesh>();
                r.name.text = Manager.gManager.sala.jugadores[i].nombre.Substring(2);
                r.slider = s.GetComponent<Slider>();
                r.slider.handleRect.GetComponent<Image>().sprite = Manager.gManager.playerR.getSlide(Manager.gManager.sala.jugadores[i].nombre.Substring(0,2));
                Manager.gManager.rivales.Add(r);
            }
            else
            {
                s = (GameObject)Instantiate(sliderPlayer, contenedorPlayers.transform.position, Quaternion.identity);
                Lemon j = g.AddComponent<Lemon>();
                Manager.gManager.lemon = j;
                j.name = GetComponentInChildren<TextMesh>();
                j.slide = s.GetComponent<Slider>();
                j.slide.handleRect.GetComponent<Image>().sprite = Manager.gManager.playerR.getSlide(Manager.gManager.sala.jugadores[i].nombre.Substring(0,2));
            }
            g.transform.SetParent(contenedorPlayers.transform);
            s.transform.SetParent(contenedorSliders.transform);
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
        contenedorPlayers.transform.position = new Vector2(contenedorPlayers.transform.position.x - (diferencia*0.2f), contenedorPlayers.transform.position.y);
        Manager.gManager.lemon.transform.position = posContenedorInicial;
    }
	// Update is called once per frame
	void Update () {
        if (Manager.gManager.finalizo) { Application.LoadLevel(4); Manager.gManager.finalizo = false; }
        if (distanciaRecorrida - diferenciaDistancia >= 0.315f)
        {
            diferenciaDistancia = distanciaRecorrida;
            Manager.gManager.cli.correr();
            Manager.gManager.lemon.slide.value += 1;
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
