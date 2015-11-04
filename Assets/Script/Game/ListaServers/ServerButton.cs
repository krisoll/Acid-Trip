using UnityEngine;
using System.Collections;

public class ServerButton : MonoBehaviour {
    public Sala sala;
    public ServerScreen server;
    public void UnirseSala()
    {
        Manager.gManager.setNombre(server.field.text);
        Manager.gManager.sala = sala;
        Manager.gManager.cli.unirse(sala);
        Manager.gManager.LoadLevel(2);
    }
}
