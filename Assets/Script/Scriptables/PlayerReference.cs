using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class PlayerReference : ScriptableObject
{
    [SerializeField]
    public List<string> nombre = new List<string>();
    [SerializeField]
    public List<Sprite> reference = new List<Sprite>();
    [SerializeField]
    public List<Sprite> slide = new List<Sprite>();
    [SerializeField]
    public List<GameObject> prefab = new List<GameObject>();
    public Sprite getReference(string nom)
    {
        Sprite refe = null;
        for(int i = 0; i < nombre.Count; i++)
        {
            if (nombre[i] == nom)
            {
                refe = reference[i];
            }
        }
        return refe;
    }
    public Sprite getSlide(string nom)
    {
        Sprite refe = null;
        for (int i = 0; i < nombre.Count; i++)
        {
            if (nombre[i] == nom)
            {
                refe = slide[i];
            }
        }
        return refe;
    }
    public GameObject getPrefab(string nom)
    {
        GameObject pref = null;
        for (int i = 0; i < nombre.Count; i++)
        {
            if (nombre[i] == nom)
            {
                pref = prefab[i];
            }
        }
        return pref;
    }
}