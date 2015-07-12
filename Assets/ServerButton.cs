using UnityEngine;
using System.Collections;

public class ServerButton : MonoBehaviour {
    public Sala sala;
    public Cliente cli;
    public void UnirseSala()
    {
        cli.unirse(sala);
    }
}
