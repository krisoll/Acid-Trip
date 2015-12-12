using UnityEngine;
using System.Collections;
using UnityEditor;
public class CreateScriptable{
    [MenuItem("Assets/ScriptableObjects/PlayerReference")]
    public static void CreatePortrait()
    {
        PlayerReference scr = ScriptableObject.CreateInstance<PlayerReference>();
        AssetDatabase.CreateAsset(scr, "Assets/Resources/Prefabs/ScriptableObjects/PlayerReference.asset");
        AssetDatabase.SaveAssets();
        Selection.activeObject = scr;
    }
}
