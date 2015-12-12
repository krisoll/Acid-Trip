using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
[System.Serializable]
[CustomEditor(typeof(PlayerReference))]
public class PlayerReferenceEditor : Editor
{
    [SerializeField]
    private PlayerReference pr;
    // Use this for initialization
    void Awake()
    {
        pr = (PlayerReference)target;
    }

    // Update is called once per frame
    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Item"))
        {
            addItem();
        }
        if (GUILayout.Button("Remove Item"))
        {
            removeItem();
        }
        EditorGUILayout.EndHorizontal();
        for (int i = 0; i < pr.nombre.Count; i++) {
            EditorGUILayout.BeginVertical("Button");
            EditorGUILayout.LabelField("Elemento" + i,EditorStyles.boldLabel);
            EditorGUILayout.Space();
            pr.nombre[i] = EditorGUILayout.TextField("Prefijo", pr.nombre[i]);
            pr.reference[i] = (Sprite)EditorGUILayout.ObjectField("Imagen Referencia", pr.reference[i], typeof(Sprite), false);
            pr.slide[i] = (Sprite)EditorGUILayout.ObjectField("Imagen Slider", pr.slide[i], typeof(Sprite), false);
            pr.prefab[i] = (GameObject)EditorGUILayout.ObjectField("Prefab", pr.prefab[i], typeof(GameObject), false);
            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();
        }
        if (GUI.changed) { EditorUtility.SetDirty(target); }
    }
    void addItem()
    {
        pr.nombre.Add("");
        pr.reference.Add(null);
        pr.slide.Add(null);
        pr.prefab.Add(null);
    }
    void removeItem()
    {
        if (pr.nombre.Count > 0)
        {
            pr.nombre.RemoveAt(pr.nombre.Count - 1);
            pr.reference.RemoveAt(pr.reference.Count - 1);
            pr.slide.RemoveAt(pr.slide.Count - 1);
            pr.prefab.RemoveAt(pr.prefab.Count - 1);
        }
    }
}