using UnityEngine;
using System.Collections;
using UnityEditor;
[System.Serializable]
[CustomEditor(typeof(ServerScreen))]
public class ServerEditor : Editor {
    ServerScreen serv;
    void Awake()
    {
        serv = target as ServerScreen;
    }
    public override void OnInspectorGUI()
    {
        serv.Panel = (GameObject)EditorGUILayout.ObjectField("Panel", serv.Panel,typeof(GameObject));
        serv.salaPrefab = (GameObject)EditorGUILayout.ObjectField("Prefab Sala", serv.salaPrefab, typeof(GameObject));
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Iniciar Conexion"))
        {
            serv.IniciarConexion();
        }
        if (GUILayout.Button("Cerrar Conexion"))
        {
            serv.CerrarConexion();
        }
        EditorGUILayout.EndHorizontal();
    }
}
