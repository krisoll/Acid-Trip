using UnityEngine;
using System.Collections;

public class BtnVolver : MonoBehaviour {
    public void MenuPrincipal()
    {
        Destroy(Manager.gManager.gameObject);
        Application.LoadLevel(0);
    }
}
