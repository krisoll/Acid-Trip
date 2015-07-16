using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Resultados : MonoBehaviour {
    public Text txt;
    void Start()
    {
        txt.text = Manager.gManager.ganador.nombre;
        Manager.gManager.rivales = null;
        Manager.gManager.sala = null;
        Manager.gManager.admin = false;
    }
}
