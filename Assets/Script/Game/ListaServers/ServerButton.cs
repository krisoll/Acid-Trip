using UnityEngine;
using System.Collections;

public class ServerButton : MonoBehaviour {
    public Sala sala;
    public void UnirseSala()
    {
        Manager.gManager.sala = sala;
        Manager.gManager.cli.unirse(sala);
        Manager.gManager.LoadLevel(2);
    }
}
