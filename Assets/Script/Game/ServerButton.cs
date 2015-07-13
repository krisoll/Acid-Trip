using UnityEngine;
using System.Collections;

public class ServerButton : MonoBehaviour {
    public Sala sala;
    public Cliente cli;
    public void UnirseSala()
    {
        Manager.gManager.sala = sala;
        Manager.gManager.cli = cli;
        cli.unirse(sala);
        Manager.gManager.LoadLevel(0);
    }
}
