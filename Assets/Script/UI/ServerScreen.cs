using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class ServerScreen : MonoBehaviour {
    public GameObject Panel;
    public GameObject salaPrefab;
    public InputField field;
    void Start()
    {

    }

	void Update(){
        GetSalas();
	}
    void GetSalas()
    {
        if (!Manager.gManager.hayNuevasSalas)
            return;
        float ySize = 0;
        ServerButton[] gs = Panel.GetComponentsInChildren<ServerButton>();
        for (int i = 0; i < gs.Length; i++)
        {
            Destroy(gs[i].gameObject);
        }
        foreach (Sala sala in Manager.gManager.salas)
        {
            GameObject g = (GameObject)Instantiate(salaPrefab, Panel.transform.position, Quaternion.identity);
            g.GetComponent<ServerButton>().sala = sala;
            g.GetComponent<ServerButton>().server = this;
            g.transform.SetParent(Panel.transform);
            g.transform.localScale = salaPrefab.transform.localScale;
            g.transform.localPosition = new Vector3(0, ySize, 0);
            ySize -= -40f;
            Text t = g.GetComponentInChildren<Text>();
            t.text = sala.nombre + " x " + sala.distancia + " > " + sala.jugadores.Length + " > " + sala.estado;
        }
        Manager.gManager.hayNuevasSalas = false;
    }
}
