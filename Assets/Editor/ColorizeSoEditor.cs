using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ColorizeSO))]
public class ColorizeSoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ColorizeSO myScript = (ColorizeSO)target;

        EditorUtility.SetDirty(myScript);

        DrawDefaultInspector();

        if(myScript.colorizers == null)
        {
            myScript.colorizers = new List<Colorize>();
        }

        foreach (var aux in ColorizeUtils.ReadPatterns())
        {
            if (!myScript.colorizers.Exists(x => x.objName == aux))
            {
                Debug.Log("Chamouy");
                Colorize cSo = new Colorize();
                cSo.objName = aux;
                cSo.color = new Color(0, 0, 0, 255);
                myScript.colorizers.Add(cSo);
            }
        }

        foreach (var aux in myScript.colorizers)
        {
            GUILayout.BeginHorizontal();    

            GUILayout.Label(aux.objName);

            aux.color = EditorGUILayout.ColorField(aux.color);

            GUILayout.EndHorizontal();
        }
    }

}
