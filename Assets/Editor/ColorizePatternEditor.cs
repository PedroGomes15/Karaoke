using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ColorizePatternEditor : EditorWindow
{
    static EditorWindow window;

    List<string> patterns = new List<string>();

    [MenuItem("Karaoke/Colorize Pattern Editor")]
    static void Init()
    {
        window = GetWindow<ColorizePatternEditor>("Colorize Pattern Editor");
        window.Show();
    }

    private void Awake()
    {
        patterns = GetPatterns();
        //SetupColorize();
    }

    void OnGUI()
    {
        SetupColorize();
    }

    void SetupColorize()
    {
        EditorUtility.SetDirty(this);
        GUIContent sName = new GUIContent();
        GUIStyle customButton = new GUIStyle("button");

        for (int i = 0; i < patterns.Count; i++)
        {
            if (patterns[i] != null)
            {
                GUILayout.BeginHorizontal();

                patterns[i] = EditorGUILayout.TextField(patterns[i]);

                if (GUILayout.Button("X", GUILayout.Width(20)))
                {
                    patterns.RemoveAt(i);
                }

                GUILayout.EndHorizontal();
            }
        }

        GUILayout.BeginHorizontal();

        customButton.fontSize = 12;

        if (GUILayout.Button("Resetar", customButton, GUILayout.Height(20)))
        {
            btnResetPattern();
        }

        customButton.fontSize = 20;
        if (GUILayout.Button("+", customButton, GUILayout.Height(20)))
        {
            btnNewPattern();
        }

        customButton.fontSize = 12;
        if (GUILayout.Button("Salvar", customButton, GUILayout.Height(20)))
        {
            btnSavePattern();
        }

        GUILayout.EndHorizontal();
    }

    List<string> GetPatterns()
    {
        return ColorizeUtils.ReadPatterns();
    }

    void btnNewPattern()
    {
        patterns.Add("");
    }

    void btnSavePattern()
    {
        string pattern = "";
        foreach (var aux in patterns)
        {
            if(pattern == "")
            {
                pattern += aux;
            }
            else
            {
                pattern += "\n" + aux ;
            }
        }

        ColorizeUtils.WriteFileColorized(pattern);
    }

    void btnResetPattern()
    {
        patterns = GetPatterns();
    }
}
