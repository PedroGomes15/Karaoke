using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ColorizePatterEditor : EditorWindow
{
    static EditorWindow window;

    string filename = "ColorizePattern.txt";

    List<string> patterns = new List<string>();

    [MenuItem("Karaoke/Colorize Pattern Editor")]
    static void Init()
    {
        window = GetWindow<ColorizePatterEditor>("Colorize Pattern Editor");
        window.Show();
    }

    private void Awake()
    {
        patterns = GetPatterns();
        SetupColorize();
    }

    void OnGUI()
    {
        SetupColorize();
    }

    void SetupColorize()
    {
        GUIContent sName = new GUIContent();

        GUILayout.BeginVertical();

        for (int i = 0; i < patterns.Count; i++)
        {
            string aux = patterns[i];

            aux = EditorGUILayout.TextField(sName, aux);

        }

        GUIStyle customButton = new GUIStyle("button");
        customButton.fontSize = 20;

        if (GUILayout.Button("+", customButton, GUILayout.Height(20)))
        {
            btnNewPattern();
        }

        GUILayout.EndVertical();
    }

    List<string> GetPatterns()
    {
        string file = File.ReadAllText(Application.streamingAssetsPath + "/" + filename);
        List<string> patterns = new List<string>();
        foreach(var aux in file.Split('\n'))
        {
            patterns.Add(aux);
        }
        return patterns;
    }

    void btnNewPattern()
    {
        patterns.Add("");
    }

    void btnSaveText()
    {

    }

    void btnResetText()
    {
        patterns = GetPatterns();
    }
}
