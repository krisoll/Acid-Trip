using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CreateServerButton : MonoBehaviour {
    public int distancia = 1000;
    public string name = "Server";
    public ServerScreen server;
    private Sala sala;
    public void UnirseSala()
    {
        sala = new Sala();
        int random = Random.Range(0, 100);
        sala.nombre = name+random;
        sala.distancia = 500;
        sala.distancia = distancia;
        Manager.gManager.setNombre(server.select.selectedSkin + server.field.text);
        Manager.gManager.Connect();
        Manager.gManager.admin = true;
        Manager.gManager.sala = sala;
        Manager.gManager.cli.crearSala(sala);
        Manager.gManager.cli.unirse(sala);
        Manager.gManager.LoadLevel(2);
    }
}
