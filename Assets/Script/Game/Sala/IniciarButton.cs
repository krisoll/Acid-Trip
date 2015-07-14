using UnityEngine;
using System.Collections;

public class IniciarButton : MonoBehaviour {

    public Sala sala;
    public void IniciarCarrera()
    {
        Manager.gManager.cli.iniciarCarrera();
        Manager.gManager.LoadLevel(3);
    }
}
